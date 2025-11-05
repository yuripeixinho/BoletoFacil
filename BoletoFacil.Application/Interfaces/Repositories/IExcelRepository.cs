using BoletoFacil.Application.DTOs.Common;

namespace BoletoFacil.Application.Interfaces.Repositories;

public interface IExcelRepository
{
    ConfiguracaoRemessaDTO LerPlanilha(Stream excelStream);
}
