using AutoMapper;
using CrossAgerTest.Application.Models.Commands.ClientsGroup;
using CrossAgerTest.Application.Models.Responses.ClientsGroup;
using CrossAgerTest.Domain.Services.Abstractions;
using MediatR;

namespace CrossAgerTest.Application.Handlers.ClientsGroup;

public class GetClientsGroupHandler(
    IRestManagerService restManagerService,
    IMapper mapper) : IRequestHandler<GetClientsGroupCommand, ClientsGroupResponseModel>
{
    public Task<ClientsGroupResponseModel> Handle(
        GetClientsGroupCommand request,
        CancellationToken cancellationToken)
    {
        var clientsGroupDto = restManagerService.Lookup(request.Id);

        return Task.FromResult(mapper.Map<ClientsGroupResponseModel>(clientsGroupDto));
    }
}