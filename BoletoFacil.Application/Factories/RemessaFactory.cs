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
            //("237", "CNAB400") => new BradescoRemessa400Generator(),
            //("237", "CNAB240") => new BradescoRemessa240Generator(),

            //("001", "CNAB400") => new BancoDoBrasilRemessa400Generator(),
            //("001", "CNAB240") => new BancoDoBrasilRemessa240Generator(),

            ("341", "400") => new BancoItauRemessaGenerator400(_mapper),
            //("001", "CNAB240") => new BancoDoBrasilRemessa240Generator(),

            _ => throw new InvalidOperationException(
                $"Banco {banco} com layout {layout} não suportado."
            )
        };
    }
}