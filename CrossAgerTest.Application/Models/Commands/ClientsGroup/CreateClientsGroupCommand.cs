using CrossAgerTest.Application.Models.Requests.ClientsGroup;
using CrossAgerTest.Application.Models.Responses.ClientsGroup;
using MediatR;

namespace CrossAgerTest.Application.Models.Commands.ClientsGroup;

public class CreateClientsGroupCommand : IRequest<ClientsGroupResponseModel>
{
    public CreateClientsGroupRequestModel CreateClientsGroupRequestModel { get; set; }
}