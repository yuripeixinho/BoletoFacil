using BoletoFacil.Application.DTOs.Common;

namespace BoletoFacil.Application.Strategies.CreateRemessa;

public interface IRemessaGenerator
{
    string CarregarLayoutEspecifico(ConfiguracaoRemessaDTO remessaDTO);
    //string CarregarLayout(ConfiguracaoRemesssaDTO remessaDTO);
}
