using BoletoFacil.Application.DTOs.Common;
using BoletoFacil.Application.Interfaces.Repositories;
using ClosedXML.Excel;
using System.Globalization;

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
                InstrucaoCancelamento = sheet.Cell(row, 6).GetString(), // Coluna F
                NumeroCarteira = sheet.Cell(row, 7).GetString(), // Coluna G
                DataVencimento = LerDataVencimento(sheet.Cell(row, 8)), // Coluna H
                ValorCobranca = sheet.Cell(row, 9).GetString(), // Coluna I
                EspecieTitulo = sheet.Cell(row, 10).GetString(), // Coluna J
                Instrucao1 = sheet.Cell(row, 11).GetString(), // Coluna K
                Instrucao2 = sheet.Cell(row, 12).GetString(), // Coluna L

            };

            detalhes.Add(item);
        }

        return detalhes;
    }

    private DateTime LerDataVencimento(IXLCell cell)
    {
        if (cell.IsEmpty())
            throw new Exception("Data de Vencimento não informada");

        // Excel como texto → valida formato DD/MM/AAAA
        if (cell.DataType == XLDataType.Text)
        {
            var texto = cell.GetString().Trim();

            if (!DateTime.TryParseExact(
                    texto,
                    "dd/MM/yyyy",
                    CultureInfo.GetCultureInfo("pt-BR"),
                    DateTimeStyles.None,
                    out var data))
            {
                throw new Exception(
                    $"Data de Vencimento inválida. Formato esperado: DD/MM/AAAA. Valor recebido: '{texto}'");
            }

            return data;
        }

        if (cell.DataType == XLDataType.Number)
        {
            return DateTime.FromOADate(cell.GetDouble());
        }

        if (cell.DataType == XLDataType.DateTime)
        {
            return cell.GetDateTime();
        }

        throw new Exception("Formato de Data de Vencimento não reconhecido");
    }
}