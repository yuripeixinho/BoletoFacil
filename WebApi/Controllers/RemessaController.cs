using BoletoFacil.Application.DTOs.Common;
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

    [HttpGet("excel/templates/itau-cnab400")]
    [Produces("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")]
    public IActionResult DownloadTemplateItau400([FromServices] IWebHostEnvironment env)
    {
        var path = Path.Combine(
            env.WebRootPath,
            "templates",
            "itau_cnab400.xlsx"
        );

        if (!System.IO.File.Exists(path))
            return NotFound("Template não encontrado.");

        var bytes = System.IO.File.ReadAllBytes(path);

        return File(
            bytes,
            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
            "itau_cnab400.xlsx"
        );
    }

    [HttpPost("excel/generate")]
    public async Task<IActionResult> GerarCnabExcel([FromForm] ExcelRemessaDTO ExcelRemessaDTO)
    {
        var command = new CreateRemessaCommand(ExcelRemessaDTO);
        var result = await _mediator.Send(command);

        var nomeArquivo = $"remessa_{DateTime.Now:yyyyMMddHHmmss}.txt";

        return File(
            result,
            "text/plain",
            nomeArquivo
        );
    }
}
