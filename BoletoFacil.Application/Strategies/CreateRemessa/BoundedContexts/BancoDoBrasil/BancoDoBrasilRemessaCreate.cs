using BoletoFacil.Application.DTOs;
using BoletoFacil.Application.Strategies.CreateRemessa.BoundedContexts.BancoDoBrasil.Layouts;
using System.Text;

namespace BoletoFacil.Application.Strategies.CreateRemessa.BoundedContexts.BancoDoBrasil;

public class BancoDoBrasilRemessaGenerator : IRemessaGenerator
{
    public string CarregarLayout(RemessaDTO remessaDTO)
    {
        var sb = new StringBuilder();

        var header = new HeaderBancoDoBrasil(remessaDTO?.Header).Gerar();
        sb.AppendLine(header);

        //var detalhes = new DetalheBancoDoBrasil(dto).Gerar();
        //var trailer = new TrailerBancoDoBrasil(dto).Gerar();

        return $"{header}";
    }
}