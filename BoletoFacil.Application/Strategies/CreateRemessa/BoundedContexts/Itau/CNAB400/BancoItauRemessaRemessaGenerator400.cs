using AutoMapper;
using BoletoFacil.Application.DTOs.BoundedContexts.Itau.CNAB400;
using BoletoFacil.Application.DTOs.Common;
using BoletoFacil.Application.Strategies.CreateRemessa.BoundedContexts.Itau.CNAB400.Layouts;
using System.Text;

namespace BoletoFacil.Application.Strategies.CreateRemessa.BoundedContexts.Itau.CNAB400;

public class BancoItauRemessaGenerator400 : IRemessaGenerator
{
    private readonly IMapper _mapper;

    public BancoItauRemessaGenerator400(IMapper mapper)
    {
        _mapper = mapper;
    }

    public string CarregarLayoutEspecifico(RemessaDTO remessaDTO)
    {
        var sb = new StringBuilder();

        var headerItauDTO = _mapper.Map<ItauHeader400DTO>(remessaDTO.HeaderDTO);

        var header = new StrategyHeaderItau400(headerItauDTO).Gerar();
        sb.AppendLine(header);

        //var detalhes = new DetalheBancoDoBrasil(dto).Gerar();
        //var trailer = new TrailerBancoDoBrasil(dto).Gerar();

        return sb.ToString();
    }
}