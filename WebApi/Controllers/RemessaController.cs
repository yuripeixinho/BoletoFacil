using BoletoFacil.Application.DTOs;
using BoletoFacil.Application.Features.Remessas.CreateRemessa;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BoletoFacil.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RemessaController : ControllerBase
{
    private readonly IMediator _mediator;

    public RemessaController(IMediator mediator)
    {
        _mediator = mediator;   
    }

    [HttpPost("generate")]
    public async Task<IActionResult> GenerateRemessa([FromBody] RemessaDTO remessaDTO)
    {
        var command = new CreateRemessaCommand(remessaDTO);
        var result = await _mediator.Send(command);

        return Ok(result);      
    }
}
