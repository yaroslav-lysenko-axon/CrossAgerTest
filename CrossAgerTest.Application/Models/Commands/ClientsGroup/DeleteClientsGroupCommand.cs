using CrossAgerTest.Application.Models.Requests.ClientsGroup;
using CrossAgerTest.Application.Models.Responses.ClientsGroup;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CrossAgerTest.Application.Models.Commands.ClientsGroup;

public class DeleteClientsGroupCommand : IRequest<ClientsGroupResponseModel>
{
    public DeleteClientsGroupRequestModel DeleteClientsGroupRequestModel { get; set; }
}