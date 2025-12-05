using AutoMapper;
using BoletoFacil.Application.DTOs.Common;
using BoletoFacil.Application.Factories.Interfaces;
using BoletoFacil.Application.Interfaces.Repositories;
using BoletoFacil.Application.Interfaces.Services;
using BoletoFacil.Application.Validation.Business;
using BoletoFacil.Domain.Core.Entities.Common;

namespace BoletoFacil.Application.Services;

public class RemessaService : IRemessaService
{
    private readonly IRemessaFactory _remessaFactory;
    private readonly IRemessaBusinessValidator _remessaBusinessValidator;
    private readonly IExcelRepository _excelRepository;
    private readonly IArquivoService _arquivoService;
    private readonly IValidationRemessaService _validator;
    private readonly IRemessaRepository _remessaRepository;
    private readonly IMapper _mapper;
    private readonly IRegrasCNABFactory _regrasCNABFactory; 

    public RemessaService(
        IRemessaFactory remessaFactory,
        IRemessaBusinessValidator remessaBusinessValidator,
        IExcelRepository excelRepository,
        IArquivoService arquivoService,
        IValidationRemessaService validationRemessaService,
        IRemessaRepository remessaRepository,
        IMapper mapper,
        IRegrasCNABFactory regrasCNABFactory)
    {
        _remessaFactory = remessaFactory;
        _remessaBusinessValidator = remessaBusinessValidator;
        _excelRepository = excelRepository;
        _arquivoService = arquivoService;
        _validator = validationRemessaService;
        _remessaRepository = remessaRepository;
        _mapper = mapper;
        _regrasCNABFactory = regrasCNABFactory;
    }

    public async Task<string> GerarRemessaAsync(ExcelRemessaDTO excelRemessaDTO)
    {
        // identificar 
        var dados = IdentificarBancoELayoutCNAB(excelRemessaDTO);
        await _validator.ValidarAsync(dados);
        await _remessaBusinessValidator.ValidarGeracaoRemessaAsync(dados);

        // regras de negócio
        RegrasNegocioPorBanco(dados);

        // factory para carregar o layout
        var layout = _remessaFactory.IdentificarRemessaPorBancoELayout(dados.Banco, dados.Layout); // Factory
        var cnab = layout.CarregarLayoutEspecifico(dados); // A partir da escolha do Factory gera o Strategy para o banco e layout correspondente

        // mapear 
        var remessaEntity = _mapper.Map<Remessa>(dados);
        remessaEntity.ArmazenarCNAB(cnab);  

        // consistir na base de dados
        await _remessaRepository.SalvarRemessaAsync(remessaEntity);

        // exportar txt 
        _arquivoService.ExportarArquivoTXT(cnab);
            
        return "Arquivo gerado com sucesso";
    }

    private RemessaDTO IdentificarBancoELayoutCNAB(ExcelRemessaDTO excelRemessaDTO)
    {
        using var planilha = excelRemessaDTO.LayoutExcel.OpenReadStream();
        var dados = _excelRepository.LerPlanilha(planilha);

        return dados;
    }
    
    private void RegrasNegocioPorBanco(RemessaDTO dados)
    {
        var regras = _regrasCNABFactory.ObterRegras(dados.Banco, dados.Layout);

        regras.Aplicar(dados);
    }
}