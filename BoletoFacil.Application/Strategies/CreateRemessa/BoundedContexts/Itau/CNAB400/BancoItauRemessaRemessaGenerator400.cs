using AutoMapper;
using BoletoFacil.Application.DTOs.BoundedContexts.Itau.CNAB400;
using BoletoFacil.Application.DTOs.Common;
using BoletoFacil.Application.Interfaces.Services;
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
        var cnab = new StringBuilder();

        ConstruirHeaderTXT(cnab, remessaDTO.HeaderDTO);
        ConstruirDetalheTXT(cnab, remessaDTO.DetalhesDTO);

        return cnab.ToString();
    }
    
    private void ConstruirHeaderTXT(StringBuilder sb, HeaderDTO HeaderDTO)
    {
        var headerItauDTO = _mapper.Map<ItauHeader400DTO>(HeaderDTO);

        var header = new StrategyHeaderItau400(headerItauDTO).Gerar();
        sb.AppendLine(header);
    }

    private void ConstruirDetalheTXT(StringBuilder sb, List<DetalhesDTO> detalhesDTOs)
    {
        var detalhesItauDTO = _mapper.Map<List<ItauDetalhe400DTO>>(detalhesDTOs);

        foreach (var detalhe in detalhesItauDTO)
        {
            var detalheLinha = new StrategyDetalhesItau400(detalhe).Gerar();
            sb.AppendLine(detalheLinha);
        }
    }
}