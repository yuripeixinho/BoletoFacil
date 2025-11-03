using BoletoFacil.Application.DTOs;

namespace BoletoFacil.Application.Interfaces.Repositories;

public interface IExcelRepository
{
    Task<RemessaDTO> ReadExcelAsync(Stream excelStream);    
}
