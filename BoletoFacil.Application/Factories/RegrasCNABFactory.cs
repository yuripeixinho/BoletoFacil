using BoletoFacil.Application.Factories.Interfaces;
using BoletoFacil.Application.RuleEngine.Strategies.CNAB.Base;
using BoletoFacil.Application.RuleEngine.Strategies.CNAB.Itau;
using Microsoft.Extensions.DependencyInjection;

namespace BoletoFacil.Application.Factories;

public class RegrasCNABFactory : IRegrasCNABFactory
{
    private readonly IServiceProvider _serviceProvider;

    public RegrasCNABFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;       
    }

    public IRegraCNABService ObterRegras(string banco, string layout)
    {
        return (banco, layout) switch
        {
            ("341", "400") => _serviceProvider.GetRequiredService<Itau400RegrasCNABService>(),

            _ => throw new NotImplementedException(
                $"Regras para o banco {banco} com layout {layout} não implementada."
            )
        };
    }
}
