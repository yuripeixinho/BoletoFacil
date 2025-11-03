using BoletoFacil.Application.DTOs;

namespace BoletoFacil.Application.Strategies.CreateRemessa;

public interface IRemessaGenerator
{
    string CarregarLayout(RemessaDTO remessaDTO);
}
