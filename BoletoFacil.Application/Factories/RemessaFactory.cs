using AutoMapper;
using BoletoFacil.Application.Factories.Interfaces;
using BoletoFacil.Application.Strategies.CreateRemessa;
using BoletoFacil.Application.Strategies.CreateRemessa.BoundedContexts.Itau.CNAB400;

namespace BoletoFacil.Application.Factories;

public class RemessaFactory : IRemessaFactory
{
    private readonly IMapper _mapper;

    public RemessaFactory(IMapper mapper)
    {
        _mapper = mapper;
    }

    public IRemessaGenerator IdentificarRemessaPorBancoELayout(string banco, string layout) 
    {
        return (banco, layout) switch
        {
            ("341", "400") => new BancoItauRemessaGenerator400(_mapper),

            _ => throw new InvalidOperationException(
                $"Banco {banco} com layout {layout} não suportado."
            )
        };
    }
}