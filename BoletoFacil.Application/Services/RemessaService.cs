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
    private readonly IRemessaRepository _remessaRepository;

    public RemessaService(IRemessaFactory remessaFactory, IExcelRepository excelRepository, IArquivoService arquivoService, IRemessaRepository remessaRepository)
    {
        _remessaFactory = remessaFactory;
        _excelRepository = excelRepository;
        _arquivoService = arquivoService;
        _remessaRepository = remessaRepository; 
    }


    public async Task<string> GerarRemessaAsync(ExcelRemessaDTO excelRemessaDTO)
    {
        var dados = IdentificarBancoELayoutCNAB(excelRemessaDTO);
       
        var layout = _remessaFactory.IdentificarRemessaPorBancoELayout(dados.Banco, dados.Layout); // Factory
        var cnab = layout.CarregarLayoutEspecifico(dados); // A partir da escolha do Factory gera o Strategy para o banco e layout correspondente

        _arquivoService.ExportarArquivoTXT(cnab);

        var teste = new Remessa
        {
            DimBancoId = int.Parse(dados.Banco),
            LayoutConfigurationId = int.Parse(dados.Layout),
            Header = new Header
            {
                Agencia = dados.HeaderDTO.Agencia.ToString(),  
                Conta = dados.HeaderDTO.Conta.ToString(),   
                DAC = dados.HeaderDTO.DAC.ToString(),    
                NomeEmpresa = dados.HeaderDTO.NomeEmpresa.ToString(),
                NumeroSequencialArquivo = dados.HeaderDTO.NumeroSequencialArquivo.ToString(),
            }
        };

        await _remessaRepository.SalvarRemessaAsync(teste);

        return "Arquivo gerado com sucesso";
    }

    private ConfiguracaoRemessaDTO IdentificarBancoELayoutCNAB(ExcelRemessaDTO excelRemessaDTO)
    {
        using var planilha = excelRemessaDTO.LayoutExcel.OpenReadStream();
        var dados = _excelRepository.LerPlanilha(planilha);

        return dados;
    }
}