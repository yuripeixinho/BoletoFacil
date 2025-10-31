using BoletoFacil.Application.DTOs;
using BoletoFacil.Application.Factories.Interfaces;
using BoletoFacil.Application.Interfaces;

namespace BoletoFacil.Application.Services;

public class RemessaService : IRemessaService
{
    private readonly IRemessaFactory _remessaFactory;

    public RemessaService(IRemessaFactory remessaFactory)
    {
        _remessaFactory = remessaFactory;   
    }

    public async Task<string> GenerateRemessaAsync(RemessaDTO remessaDTO)
    {
        // LER ARQUIVO EXCEL
        



        // o serviço de gerar os arquivos Header, Detalhe e Trailer
        // Escolhe qual o banco 
        var banco =  _remessaFactory.CriarRemessaParaOBanco(remessaDTO.Banco); // escolhe qual strategy (banco usar)
        var remessa = banco.CarregarLayoutAsync(); // a partir do strategy cria o CNAB










        var path = Path.Combine("C:\\Remessas", $"remessa_{DateTime.Now:yyyyMMddHHmmss}.txt");
        await File.WriteAllTextAsync(path, remessa);

        return path;
    }
}
