using BoletoFacil.Application.DTOs.BoundedContexts.Itau.CNAB400;
using System.Text;

namespace BoletoFacil.Application.Strategies.CreateRemessa.BoundedContexts.Itau.CNAB400.Layouts;

public class StrategyTrailerItau400
{
    public ItauTrailer400DTO _t;

    public StrategyTrailerItau400(ItauTrailer400DTO trailer)
    {
        _t = trailer;
    }

    public string Gerar()
    {
        var sb = new StringBuilder(400);

        sb.Append("9");
        sb.Append("".PadRight(393, ' '));
        sb.Append(_t.NumeroSequencialArquivo);

        string linha = sb.ToString();

        if (linha.Length != 400)
            throw new InvalidOperationException($"Trailer deve conter 400 posições. Atual: {linha.Length}");

        return linha;
    }
}
