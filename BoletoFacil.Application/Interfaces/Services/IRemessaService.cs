using BoletoFacil.Application.DTOs.Common;

namespace BoletoFacil.Application.Interfaces.Services;

public interface IRemessaService
{
    Task<string> GerarRemessaAsync(ExcelRemessaDTO ExcelRemessa); // serviço central que criará as remessas baseadas no banco
}
