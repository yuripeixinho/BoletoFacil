using BoletoFacil.Application.DTOs.Common;
using BoletoFacil.Application.Interfaces.Repositories;
using ClosedXML.Excel;

namespace BoletoFacil.Infrastructure.Data.Repositories;

public class ExcelRepository : IExcelRepository
{
    public ConfiguracaoRemessaDTO LerPlanilha(Stream excelStream)
    {
        using var workbook = new XLWorkbook(excelStream);
        var sheet = workbook.Worksheet("Base");

        var remessa = new ConfiguracaoRemessaDTO
        {
            Banco = sheet.Cell("A2").GetString(),
            Layout = sheet.Cell("B2").GetString(),
            
            HeaderDTO = new HeaderDTO
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
            }
        };

        return remessa;
    }
}