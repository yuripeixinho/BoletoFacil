using BoletoFacil.Application.Strategies.CreateRemessa;

namespace BoletoFacil.Application.Factories.Interfaces;

public interface IRemessaFactory
{
    IRemessaGenerator IdentificarRemessaPorBancoELayout(string banco, string layout);
}
