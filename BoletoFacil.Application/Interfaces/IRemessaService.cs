using BoletoFacil.Application.DTOs;

namespace BoletoFacil.Application.Interfaces;

public interface IRemessaService
{
    Task<string> GenerateRemessaAsync(RemessaDTO remessa); // serviço central que criará as remessas baseadas no banco.
}
