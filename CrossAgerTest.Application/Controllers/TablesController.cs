using CrossAgerTest.Application.Models.Commands.Table;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CrossAgerTest.Application.Controllers;

[ApiController]
[Route("[controller]")]
public class TablesController : ControllerBase
{
    private readonly IMediator _mediator;

    public TablesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var response = await _mediator.Send(new GetTablesCommand());

        return Ok(response);
    }
}