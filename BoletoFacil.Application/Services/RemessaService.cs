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
        var remessafactory =  _remessaFactory.CriarRemessa(remessaDTO.Banco);
        var remessaStrategy = remessafactory.GerarRemessa(remessaDTO);

        var path = Path.Combine("C:\\Remessas", $"remessa_{DateTime.Now:yyyyMMddHHmmss}.txt");
        await File.WriteAllTextAsync(path, remessaStrategy);

        return path;
    }
}
