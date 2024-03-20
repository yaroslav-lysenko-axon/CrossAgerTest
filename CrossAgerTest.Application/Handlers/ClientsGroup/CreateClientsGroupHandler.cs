using AutoMapper;
using CrossAgerTest.Application.Models.Commands.ClientsGroup;
using CrossAgerTest.Application.Models.Responses.ClientsGroup;
using CrossAgerTest.Domain.Models.Dtos;
using CrossAgerTest.Domain.Services.Abstractions;
using MediatR;

namespace CrossAgerTest.Application.Handlers.ClientsGroup;

public class CreateClientsGroupHandler(
    IRestManagerService restManagerService,
    IMapper mapper) : IRequestHandler<CreateClientsGroupCommand, ClientsGroupResponseModel>
{
    public async Task<ClientsGroupResponseModel> Handle(
        CreateClientsGroupCommand request,
        CancellationToken cancellationToken)
    {
        ClientsGroupDto clientsGroupDto = mapper.Map<ClientsGroupDto>(request.CreateClientsGroupRequestModel);
        
        var response = await restManagerService.OnArrive(clientsGroupDto);

        return mapper.Map<ClientsGroupResponseModel>(response);
    }
}