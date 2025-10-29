using BoletoFacil.Domain.Core.Entities;

namespace BoletoFacil.Application.Interfaces;

public interface IRemessaService
{
    Task<string> GerarRemessaAsync(Remessa remessa); // serviço central que criará as remessas baseadas no banco.
}
