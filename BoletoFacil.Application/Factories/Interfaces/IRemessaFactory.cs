using BoletoFacil.Application.Strategies.CreateRemessa;

namespace BoletoFacil.Application.Factories.Interfaces;

public interface IRemessaFactory
{
    IRemessaCreate CriarRemessa(string banco);
}
