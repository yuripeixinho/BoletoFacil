using AutoMapper;
using BoletoFacil.Application.DTOs.Common;
using BoletoFacil.Application.Factories.Interfaces;
using BoletoFacil.Application.Interfaces.Repositories;
using BoletoFacil.Application.Interfaces.Services;
using BoletoFacil.Domain.Core.Entities.Common;

namespace BoletoFacil.Application.Services;

public class RemessaService : IRemessaService
{
    private readonly IRemessaFactory _remessaFactory;
    private readonly IExcelRepository _excelRepository;
    private readonly IArquivoService _arquivoService;
    private readonly IValidationRemessaService _validator;  
    private readonly IRemessaRepository _remessaRepository;
    private readonly IMapper _mapper;

    public RemessaService(IRemessaFactory remessaFactory, IExcelRepository excelRepository, IArquivoService arquivoService, IValidationRemessaService validationRemessaService, 
        IRemessaRepository remessaRepository, IMapper mapper)
    {
        _remessaFactory = remessaFactory;
        _excelRepository = excelRepository;
        _arquivoService = arquivoService;
        _validator = validationRemessaService;  
        _remessaRepository = remessaRepository;
        _mapper = mapper;
    }

    public async Task<string> GerarRemessaAsync(ExcelRemessaDTO excelRemessaDTO)
    {
        var dados = IdentificarBancoELayoutCNAB(excelRemessaDTO);
        await _validator.ValidarAsync(dados); 

        var layout = _remessaFactory.IdentificarRemessaPorBancoELayout(dados.Banco, dados.Layout); // Factory
        var cnab = layout.CarregarLayoutEspecifico(dados); // A partir da escolha do Factory gera o Strategy para o banco e layout correspondente



        var remessaEntity = _mapper.Map<Remessa>(dados);
        remessaEntity.ArmazenarCNAB(cnab);  

        await _remessaRepository.SalvarRemessaAsync(remessaEntity);

        _arquivoService.ExportarArquivoTXT(cnab);
            
        return "Arquivo gerado com sucesso";
    }

    private RemessaDTO IdentificarBancoELayoutCNAB(ExcelRemessaDTO excelRemessaDTO)
    {
        using var planilha = excelRemessaDTO.LayoutExcel.OpenReadStream();
        var dados = _excelRepository.LerPlanilha(planilha);

        return dados;
    }
}