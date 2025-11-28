using BoletoFacil.Application.RuleEngine.Strategies.CNAB.Base;

namespace BoletoFacil.Application.Factories.Interfaces;

public interface IRegrasCNABFactory
{
    IRegraCNABService ObterRegras(string banco, string layout);
}
