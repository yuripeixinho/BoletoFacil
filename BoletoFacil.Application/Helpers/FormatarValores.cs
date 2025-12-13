using System.Globalization;

namespace BoletoFacil.Application.Helpers;

public static class FormatarValores
{
    public static string ValorCobranca(string valor, string tamanhoFixo)
    {
        if (!decimal.TryParse(
                valor,
                NumberStyles.Number,
                CultureInfo.GetCultureInfo("pt-BR"),
                out var valorDecimal))
        {
            throw new ArgumentException($"Valor inválido: {valor}");
        }

        // Remove separador decimal e garante 2 casas
        var valorSemSeparador = (valorDecimal * 100).ToString(tamanhoFixo);

        return valorSemSeparador;
    }
}