using CrossAgerTest.Application.Models.Responses.ClientsGroup;
using MediatR;

namespace CrossAgerTest.Application.Models.Commands.ClientsGroup;

public class GetClientsGroupCommand : IRequest<ClientsGroupResponseModel>
{
    public int Id { get; set; }
}