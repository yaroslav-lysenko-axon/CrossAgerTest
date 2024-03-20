using AutoMapper;
using CrossAgerTest.Application.Models.Commands.ClientsGroup;
using CrossAgerTest.Application.Models.Responses.ClientsGroup;
using CrossAgerTest.Domain.Services.Abstractions;
using MediatR;

namespace CrossAgerTest.Application.Handlers.ClientsGroup;

public class DeleteClientsGroupHandler(
    IRestManagerService restManagerService,
    IMapper mapper) : IRequestHandler<DeleteClientsGroupCommand, ClientsGroupResponseModel>
{
    public async Task<ClientsGroupResponseModel> Handle(
        DeleteClientsGroupCommand request,
        CancellationToken cancellationToken)
    {
        var response = await restManagerService.OnLeave(request.DeleteClientsGroupRequestModel.Id);

        return mapper.Map<ClientsGroupResponseModel>(response);
    }
}