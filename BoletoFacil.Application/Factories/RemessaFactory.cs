using BoletoFacil.Application.Factories.Interfaces;
using BoletoFacil.Application.Strategies.CreateRemessa.BoundedContexts;

namespace BoletoFacil.Application.Factories;

public class RemessaFactory : IRemessaFactory
{
    public IRemessaGenerator CriarRemessaParaOBanco(string banco) => banco switch
    {
        "Bradesco" => new BradescoRemessaGenerator(),
        "BancoDoBrasil" => new BancoDoBrasilRemessaGenerator(),
        _ => throw new InvalidOperationException($"Banco {banco} não suportado.")
    };
}
