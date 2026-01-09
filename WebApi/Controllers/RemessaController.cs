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

    /// <summary>
    /// Realiza o download do template de planilha para remessa CNAB 400 do Banco Itaú.
    /// </summary>
    /// <remarks>
    /// Este endpoint disponibiliza um arquivo modelo em formato Excel (.xlsx),
    /// utilizado como base para o preenchimento dos dados necessários à geração
    /// do arquivo de remessa CNAB 400 no BoletoFácil.
    ///
    /// O template segue o layout padrão exigido pelo Banco Itaú, garantindo
    /// compatibilidade e reduzindo erros de validação durante o processamento
    /// da remessa bancária.
    /// </remarks>
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


    /// <summary>
    /// Gerar CNAB eletrônico baseado na planilha enviada
    /// </summary>
    /// <remarks>
    /// Este endpoint realiza a leitura da planilha e identifica o layout e banco automaticamente. 
    /// 
    /// Com base na planilha enviada, o endpoint identifica o banco e layout e gera o arquivo bancário apropriado.
    /// </remarks>
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
