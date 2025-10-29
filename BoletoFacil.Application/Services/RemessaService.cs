using BoletoFacil.Application.Interfaces;
using BoletoFacil.Domain.Core.Entities;
using System.Text;

namespace BoletoFacil.Application.Services;

public class RemessaService : IRemessaService
{



    public Task<string> GerarRemessaAsync(Remessa remessa)
    {
        var gerador = _factory.CriarGerador(remessa);
        var conteudo = gerador.GerarRemessa(remessa);

        //var caminho = Path.Combine("C:\\Remessas", $"remessa_{DateTime.Now:yyyyMMddHHmmss}.txt");
        //Directory.CreateDirectory(Path.GetDirectoryName(caminho)!);
        //await File.WriteAllTextAsync(caminho, conteudo, Encoding.ASCII);

        //return caminho;
    }
}
