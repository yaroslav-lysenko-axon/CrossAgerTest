using CrossAgerTest.Application.Models.Commands.ClientsGroup;
using CrossAgerTest.Application.Models.Requests.ClientsGroup;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CrossAgerTest.Application.Controllers;

[ApiController]
[Route("[controller]")]
public class ClientsGroupsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ClientsGroupsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] int id)
    {
        var response = await _mediator.Send(new GetClientsGroupCommand
        {
            Id = id
        });

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateClientsGroupRequestModel requestModel)
    {
        var response = await _mediator.Send(new CreateClientsGroupCommand
        {
            CreateClientsGroupRequestModel = requestModel
        });

        return Ok(response);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteClientsGroupRequestModel requestModel)
    {
        var response = await _mediator.Send(new DeleteClientsGroupCommand
        {
            DeleteClientsGroupRequestModel = requestModel
        });

        return Ok(response);
    }
}