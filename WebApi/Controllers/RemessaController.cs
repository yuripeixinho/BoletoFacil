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

    [HttpPost("excel/generate/240")]
    public async Task<IActionResult> GerarCnab240PorExcel([FromForm] LeituraExcelDTO ExcelRemessaDTO)
    {
        var command = new CreateRemessaCommand(ExcelRemessaDTO);
        var result = await _mediator.Send(command);

        return Ok(result);      
    }
}
