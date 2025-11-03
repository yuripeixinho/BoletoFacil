using BoletoFacil.Application.DTOs;
using BoletoFacil.Application.Interfaces.Repositories;
using ClosedXML.Excel;

namespace BoletoFacil.Infrastructure.Data.Repositories;

public class ExcelRepository : IExcelRepository
{
    public async Task<RemessaDTO> ReadExcelAsync(Stream excelStream)
    {
        using var workbook = new XLWorkbook(excelStream);

        var remessa = new RemessaDTO();

        var header = LerHeaderPlanilha(workbook, remessa);

        return await Task.FromResult(remessa);
    }

    private RemessaDTO LerHeaderPlanilha(XLWorkbook workbook, RemessaDTO remessa)
    {
        var sheet = workbook.Worksheet("header");

        remessa.Header = new BBHeader240DTO
        {
            CodigoBanco = sheet.Cell("A2").GetString(),
            TipoInscricao = sheet.Cell("B2").GetString(),
            Inscricao = sheet.Cell("C2").GetString(),
            Convenio = sheet.Cell("D2").GetString(),
            Agencia = sheet.Cell("E2").GetString(),
            DVAgencia = sheet.Cell("F2").GetString(),
            Conta = sheet.Cell("G2").GetString(),
            DVConta = sheet.Cell("H2").GetString(),
            NomeEmpresa = sheet.Cell("I2").GetString(),
            NumeroSequencialArquivo = sheet.Cell("J2").GetString()
        };

        return remessa; 
    }
}
