using BoletoFacil.Application.Strategies.CreateRemessa;

namespace BoletoFacil.Application.Factories.Interfaces;

public interface IRemessaFactory
{
    IRemessaGenerator CriarRemessaParaOBanco(string banco);
}
