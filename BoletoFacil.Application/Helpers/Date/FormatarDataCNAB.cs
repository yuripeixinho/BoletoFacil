using System.Globalization;

namespace BoletoFacil.Application.Helpers.Date;

public static class FormatarDataCNAB
{
    private static readonly CultureInfo CulturaInvariant =  CultureInfo.InvariantCulture;

    public static string FormatarDDMMAA(DateTime data)
    {
        return data.ToString("ddMMyy", CulturaInvariant);
    }
}
