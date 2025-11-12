using BoletoFacil.Application.DTOs.Common;
using BoletoFacil.Application.Interfaces.Repositories;
using ClosedXML.Excel;

namespace BoletoFacil.Infrastructure.Data.Repositories;

public class ExcelRepository : IExcelRepository
{
    public RemessaDTO LerPlanilha(Stream excelStream)
    {
        using var workbook = new XLWorkbook(excelStream);
        var sheet = workbook.Worksheet("Base");

        var HeaderDTO = LerHeader(workbook);

        var remessa = new RemessaDTO
        {
            Banco = sheet.Cell("A2").GetString(),
            Layout = sheet.Cell("B2").GetString(),
            HeaderDTO = HeaderDTO,  
        };

        return remessa;
    }

    private HeaderDTO LerHeader(XLWorkbook workbook)
    {
        var sheet = workbook.Worksheet("Header");

        var HeaderDTO = new HeaderDTO
        {
            Agencia = sheet.Cell("A2").GetString(),
            Conta = sheet.Cell("B2").GetString(),
            DAC = sheet.Cell("C2").GetString(),
            NomeEmpresa = sheet.Cell("D2").GetString(),
            NumeroSequencialArquivo = sheet.Cell("E2").GetString()
        };

        return HeaderDTO;
    }
}