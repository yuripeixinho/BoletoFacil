using BoletoFacil.Application.DTOs.Common;
using BoletoFacil.Application.Interfaces.Repositories;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using System.ComponentModel.DataAnnotations;
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
                CodigoInscricaoId = LerIntExcel(sheet.Cell(row, 1), row, "Código de Inscrição"),
                NumeroInscricao = sheet.Cell(row, 2).GetString(),
                Agencia = sheet.Cell(row, 3).GetString(),
                Conta = sheet.Cell(row, 4).GetString(),
                DAC = sheet.Cell(row, 5).GetString(),
                InstrucaoCancelamento = sheet.Cell(row, 6).GetString(),
                NumeroCarteira = sheet.Cell(row, 7).GetString(),

                DataVencimento = LerDataExcel(sheet.Cell(row, 8), row, "Data de Vencimento", obrigatoria: true)!.Value,

                ValorCobranca = LerDecimalExcel(sheet.Cell(row, 9), row, "Valor da Cobrança"),

                EspecieTitulo = sheet.Cell(row, 10).GetString(),
                Instrucao1 = sheet.Cell(row, 11).GetString(),
                Instrucao2 = sheet.Cell(row, 12).GetString(),
                JurosMora = sheet.Cell(row, 13).GetString(),

                DataDesconto = LerDataExcel(sheet.Cell(row, 14), row, "Data de Desconto"),
                ValorDesconto = LerDecimalExcel(sheet.Cell(row, 15), row, "Valor do Desconto"),

                CodigoInscricaoPagador = sheet.Cell(row, 16).GetString(),
                NumeroInscricaoPagador = sheet.Cell(row, 17).GetString(),
                Nome = sheet.Cell(row, 18).GetString(),
                Logradouro = sheet.Cell(row, 19).GetString(),
                Bairro = sheet.Cell(row, 20).GetString(),
                CEP = sheet.Cell(row, 21).GetString(),
                Cidade = sheet.Cell(row, 22).GetString(),
                Estado = sheet.Cell(row, 23).GetString(),

                DataMora = LerDataExcel(sheet.Cell(row, 24), row, "Data de Mora"),
                PrazoDias = sheet.Cell(row, 25).GetString(),

            };

            detalhes.Add(item);
        }

        return detalhes;
    }

    private int LerIntExcel(IXLCell cell, int row, string campo)
    {
        if (cell.TryGetValue<int>(out var valor))
            return valor;

        if (int.TryParse(cell.GetString(), out valor))
            return valor;

        throw new ValidationException(
            $"Campo '{campo}' inválido na linha {row}. Valor informado: '{cell.GetString()}'");
    }

    private decimal LerDecimalExcel(IXLCell cell, int row, string campo)
    {
        if (cell.TryGetValue<decimal>(out var valor))
            return Math.Round(valor, 2);

        var texto = cell.GetString().Trim();

        if (decimal.TryParse(
                texto,
                NumberStyles.Number,
                CultureInfo.GetCultureInfo("pt-BR"),
                out valor))
        {
            return Math.Round(valor, 2);
        }

        throw new ValidationException(
            $"Campo '{campo}' inválido na linha {row}. Valor informado: '{texto}'");
    }

    private DateTime? LerDataExcel(IXLCell cell, int row, string campo, bool obrigatoria = false)   
    {
        if (cell.IsEmpty())
        {
            if (obrigatoria)
                throw new ValidationException(
                    $"Campo '{campo}' é obrigatório na linha {row}");
            return null;
        }

        if (cell.TryGetValue<DateTime>(out var data))
            return data;

        var texto = cell.GetString().Trim();

        if (DateTime.TryParseExact(
                texto,
                "dd/MM/yyyy",
                CultureInfo.GetCultureInfo("pt-BR"),
                DateTimeStyles.None,
                out data))
        {
            return data;
        }

        throw new ValidationException(
            $"Campo '{campo}' inválido na linha {row}. Formato esperado: DD/MM/AAAA. Valor recebido: '{texto}'");
    }
}