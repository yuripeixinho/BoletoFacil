using BoletoFacil.Application.Interfaces.Services;

namespace BoletoFacil.Application.Services;

public class ArquivoService : IArquivoService
{
    public async void ExportarArquivoTXT(string cnab)
    {
        var path = Path.Combine("C:\\Remessas", $"remessa_{DateTime.Now:yyyyMMddHHmmss}.txt");
        await File.WriteAllTextAsync(path, cnab);
    }
}
