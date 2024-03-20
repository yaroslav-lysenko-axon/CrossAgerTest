using AutoMapper;
using CrossAgerTest.Application.Models.Commands.Table;
using CrossAgerTest.Application.Models.Responses.Table;
using CrossAgerTest.Domain.Services.Abstractions;
using MediatR;

namespace CrossAgerTest.Application.Handlers.Table;

public class GetTablesHandler(
    IRestManagerService restManagerService,
    IMapper mapper) : IRequestHandler<GetTablesCommand, IReadOnlyCollection<TableResponseModel>>
{
    public async Task<IReadOnlyCollection<TableResponseModel>> Handle(
        GetTablesCommand request,
        CancellationToken cancellationToken)
    {
        var response = await restManagerService.GetTables();

        return mapper.Map<IReadOnlyCollection<TableResponseModel>>(response);
    }
}