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
        var DetalhesDTO = LerDetalhes(workbook);

        var remessa = new RemessaDTO
        {
            Banco = sheet.Cell("A2").GetString(),
            Layout = sheet.Cell("B2").GetString(),
            Carteira = sheet.Cell("C2").GetString(),
            HeaderDTO = HeaderDTO,
            DetalhesDTO = DetalhesDTO
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
        };

        return HeaderDTO;
    }

    private List<DetalhesDTO> LerDetalhes(XLWorkbook workbook)
    {
        var sheet = workbook.Worksheet("Detalhe");

        var detalhes = new List<DetalhesDTO>();

        var lastRow = sheet.LastRowUsed().RowNumber();

        for (int row = 2; row <= lastRow; row++)
        {
            if (sheet.Row(row).IsEmpty())
                continue;

            var item = new DetalhesDTO
            {
                CodigoInscricaoId = sheet.Cell(row, 1).GetString(),     // Coluna A
                NumeroInscricao = sheet.Cell(row, 2).GetString(),        // Coluna B
                Agencia = sheet.Cell(row, 3).GetString(),     // Coluna C
                Conta = sheet.Cell(row, 4).GetString(),     // Coluna D
                DAC = sheet.Cell(row, 5).GetString(), // Coluna E
                Instrucao = sheet.Cell(row, 5).GetString(), // Coluna E
                NossoNumero = sheet.Cell(row, 5).GetString(), // Coluna E
            };

            detalhes.Add(item);
        }

        return detalhes;
    }
}