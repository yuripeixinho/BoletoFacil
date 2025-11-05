using BoletoFacil.Application.DTOs.Common;

namespace BoletoFacil.Application.Strategies.CreateRemessa.BoundedContexts.BancoDoBrasil;

public class BancoDoBrasilRemessaGenerator : IRemessaGenerator
{
    public string CarregarLayoutEspecifico(ConfiguracaoRemessaDTO remessaDTO)
    {
        throw new NotImplementedException();
    }

    //public string CarregarLayout(RemessaDTO remessaDTO)
    //{

    //    throw NotImplementedException()
    //    var sb = new StringBuilder();

    //    var header = new HeaderBancoDoBrasil(remessaDTO?.Header).Gerar();
    //    sb.AppendLine(header);

    //    //var detalhes = new DetalheBancoDoBrasil(dto).Gerar();
    //    //var trailer = new TrailerBancoDoBrasil(dto).Gerar();

    //    return $"{header}";
    //}
    //public ConfiguracaoRemessaDTO EspecificoPorBanco(LeituraExcelDTO leituraDTO)
    //{
    //    throw new NotImplementedException();
    //}
}