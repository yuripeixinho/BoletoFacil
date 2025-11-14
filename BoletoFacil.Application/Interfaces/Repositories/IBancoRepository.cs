using BoletoFacil.Domain.Core.Entities.Dimension;

namespace BoletoFacil.Application.Interfaces.Repositories;

public interface IBancoRepository
{
    public Task<bool> ExistsAsync(string codigoBanco);
}
