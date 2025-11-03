using BoletoFacil.Application.Factories.Interfaces;
using BoletoFacil.Application.Strategies.CreateRemessa;
using BoletoFacil.Application.Strategies.CreateRemessa.BoundedContexts.BancoDoBrasil;
using BoletoFacil.Application.Strategies.CreateRemessa.BoundedContexts.Bradesco;

namespace BoletoFacil.Application.Factories;

public class RemessaFactory : IRemessaFactory
{
    public IRemessaGenerator CriarRemessaParaOBanco(string banco) => banco switch
    {
        "237" => new BradescoRemessaGenerator(),
        "001" => new BancoDoBrasilRemessaGenerator(),
        _ => throw new InvalidOperationException($"Banco {banco} não suportado.")
    };
}
