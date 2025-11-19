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
    private readonly IUsoEmpresaService _usoEmpresaService;

    public BancoItauRemessaGenerator400(IMapper mapper, IUsoEmpresaService usoEmpresaService)
    {
        _mapper = mapper;
        _usoEmpresaService = usoEmpresaService;
    }

    public string CarregarLayoutEspecifico(RemessaDTO remessaDTO)
    {
        var sb = new StringBuilder();

        // mapear para o Itau
        var headerItauDTO = _mapper.Map<ItauHeader400DTO>(remessaDTO.HeaderDTO);
        var detalhesItauDTO = _mapper.Map<List<ItauDetalhe400DTO>>(remessaDTO.DetalhesDTO);


        var header = new StrategyHeaderItau400(headerItauDTO).Gerar();
        sb.AppendLine(header);

        foreach (var detalhe in detalhesItauDTO)
        {
            var detalheLinha = new StrategyDetalhesItau400(detalhe, _usoEmpresaService).Gerar();
            sb.AppendLine(detalheLinha);
        }



        return sb.ToString();
    }
}