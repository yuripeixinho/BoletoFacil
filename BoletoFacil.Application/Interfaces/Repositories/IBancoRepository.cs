namespace BoletoFacil.Application.Interfaces.Repositories;

public interface IBancoRepository
{
    public Task<bool> ExistsAsync(string codigoBanco);
}
