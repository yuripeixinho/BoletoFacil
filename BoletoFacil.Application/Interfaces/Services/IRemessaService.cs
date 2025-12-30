using BoletoFacil.Application.DTOs.Common;

namespace BoletoFacil.Application.Interfaces.Services;

public interface IRemessaService
{
    Task<byte[]> GerarRemessaAsync(ExcelRemessaDTO excelRemessaDTO);
}
