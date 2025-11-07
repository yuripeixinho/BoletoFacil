using BoletoFacil.Application.Interfaces.Services;
using MediatR;

namespace BoletoFacil.Application.Features.Remessas.CreateRemessa;

public class CreateRemessaCommandHandler : IRequestHandler<CreateRemessaCommand, string>
{
    private readonly IRemessaService _remessaService;

    public CreateRemessaCommandHandler(IRemessaService remessaService)
    {
        _remessaService = remessaService;   
    }

    public async Task<string> Handle(CreateRemessaCommand request, CancellationToken cancellationToken)
    {
        //A função principal do handle  não é executar nenhuma tarefa bruta (como acessar o banco de dados),
        // mas sim ORQUESTRAR a sequência dos passos que definem o processo (a lógica de negócio complexa).
        var remessa = await _remessaService.GerarRemessaAsync(request.ExcelRemessaDTO);

        return remessa;
    }
}
