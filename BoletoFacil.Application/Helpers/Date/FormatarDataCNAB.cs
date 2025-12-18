using System.Globalization;

namespace BoletoFacil.Application.Helpers.Date;

public static class FormatarDataCNAB
{
    private static readonly CultureInfo CulturaInvariant =  CultureInfo.InvariantCulture;

    public static string FormatarDDMMAA(DateTime? data)
    {
        if (data == DateTime.MinValue)
            return "000000";

        return data.Value.ToString("ddMMyy", CulturaInvariant);

    }
}
