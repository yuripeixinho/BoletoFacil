using BoletoFacil.Application.DTOs.Common;

namespace BoletoFacil.Application.Interfaces.Services;

public interface IRemessaService
{
    Task<string> GerarRemessaAsync(LeituraExcelDTO ExcelRemessa); // serviço central que criará as remessas baseadas no banco.
}
