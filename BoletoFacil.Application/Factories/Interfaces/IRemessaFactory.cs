using BoletoFacil.Application.Strategies.CreateRemessa.BoundedContexts;

namespace BoletoFacil.Application.Factories.Interfaces;

public interface IRemessaFactory
{
    IRemessaGenerator CriarRemessaParaOBanco(string banco);
}
