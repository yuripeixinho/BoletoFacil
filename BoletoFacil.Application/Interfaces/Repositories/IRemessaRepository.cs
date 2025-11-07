using BoletoFacil.Domain.Core.Entities.Common;

namespace BoletoFacil.Application.Interfaces.Repositories;

public interface IRemessaRepository
{
    Task<Remessa> SalvarRemessaAsync(Remessa remessa);
}
