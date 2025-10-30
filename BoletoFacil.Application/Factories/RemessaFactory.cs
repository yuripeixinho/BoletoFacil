using BoletoFacil.Application.Factories.Interfaces;
using BoletoFacil.Application.Strategies.CreateRemessa;

namespace BoletoFacil.Application.Factories;

public class RemessaFactory : IRemessaFactory
{
    public IRemessaCreate CriarRemessa(string banco) => banco switch
    {
        "Bradesco" => new BradescoRemessaCreate(),
        "BancoDoBrasil" => new BancoDoBrasilRemessaCreate(),
        _ => throw new InvalidOperationException($"Banco {banco} não suportado.")
    };
}
