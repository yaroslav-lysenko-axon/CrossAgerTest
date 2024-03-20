using System.Text.Json.Serialization;
using CrossAgerTest.Application.Controllers;
using CrossAgerTest.Application.Handlers.Table;
using CrossAgerTest.Application.Mappings;
using CrossAgerTest.Application.Models.Responses;
using CrossAgerTest.Domain.Contexts;
using CrossAgerTest.Domain.Mappings;
using CrossAgerTest.Domain.Models.Enums;
using CrossAgerTest.Domain.Repositories;
using CrossAgerTest.Domain.Repositories.Abstractions;
using CrossAgerTest.Domain.Services;
using CrossAgerTest.Domain.Services.Abstractions;
using CrossAgerTest.Middlewares;
using CrossAgerTest.Migrations;
using FluentMigrator.Runner;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Extensions;
using Microsoft.OpenApi.Models;
using Serilog;

const string persistenceSectionName = "Persistence";

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json");

IServiceCollection serviceCollection = builder.Services;
ConfigureServices(serviceCollection, builder);
serviceCollection.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "CrossAger Restaurant APIs" });
});

var app = builder.Build();
using var scope = app.Services.CreateScope();
UpdateDatabase(scope.ServiceProvider);

app.UseSwagger();
app.UseSwaggerUI();

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseStatusCodePages();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

void ConfigureServices(IServiceCollection services, WebApplicationBuilder webApplicationBuilder)
{
    services.AddControllers().AddNewtonsoftJson(options =>
        {
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        })
        .ConfigureApiBehaviorOptions(ConfigureFluentValidationResponse)
        .AddJsonOptions(options => { options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); })
        .AddApplicationPart(typeof(ClientsGroupsController).Assembly);

    services.AddHttpContextAccessor();

    RegisterFluentMigrator(services, webApplicationBuilder.Configuration);

    RegisterServices(services);
    RegisterRepositories(services);
    RegisterHandlers(services);

    services.AddDbContext<CrossAgerDbContext>((sp, options) =>
    {
        options.UseSqlServer(webApplicationBuilder.Configuration.GetSection($"{persistenceSectionName}:ConnectionString").Value);
    });
    
    services.AddAutoMapper(configAction => configAction.AddProfile(new ApplicationMappingsProfile()), typeof(Program));
    services.AddAutoMapper(configAction => configAction.AddProfile(new DomainMappingsProfile()), typeof(Program));
}

static void RegisterFluentMigrator(IServiceCollection services, IConfiguration configuration)
{
    services.AddFluentMigratorCore()
        .ConfigureRunner(rb => rb
            .AddSqlServer()
            .WithGlobalConnectionString(configuration.GetSection($"{persistenceSectionName}:ConnectionString").Value)
            .ScanIn(typeof(Migration001_AddTableTable).Assembly).For.Migrations());
}

static void RegisterServices(IServiceCollection services)
{
    services
        .AddScoped<IRestManagerService, RestManagerService>();
}

static void RegisterRepositories(IServiceCollection services)
{
    services
        .AddScoped<IUnitOfWork, UnitOfWork>()
        .AddScoped<ITableRepository, TableRepository>()
        .AddScoped<IClientsGroupRepository, ClientsGroupRepository>();
}

static void RegisterHandlers(IServiceCollection services)
{
    services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<GetTablesHandler>());
}

static void ConfigureFluentValidationResponse(ApiBehaviorOptions options)
{
    options.InvalidModelStateResponseFactory = c =>
    {
        var errors = c.ModelState.Values.Where(v => v.Errors.Count > 0)
            .SelectMany(v => v.Errors)
            .Select(v => v.ErrorMessage);

        var response = new ErrorResponse
        {
            Code = ErrorCode.ValidationFailed.GetDisplayName(),
            Message = string.Join(" ", errors)
        };

        return new BadRequestObjectResult(response);
    };
}

static void UpdateDatabase(IServiceProvider serviceProvider)
{
    var runner = serviceProvider.GetRequiredService<IMigrationRunner>();

    Log.Information("Starting migration...");

    runner.MigrateUp();
    runner.ListMigrations();

    Log.Information("Migration finished!");
}