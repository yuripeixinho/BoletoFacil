using BoletoFacil.Application.DTOs.Common;
using BoletoFacil.Application.Factories.Interfaces;
using BoletoFacil.Application.Interfaces.Repositories;
using BoletoFacil.Application.Interfaces.Services;

namespace BoletoFacil.Application.Services;

public class RemessaService : IRemessaService
{
    private readonly IRemessaFactory _remessaFactory;
    private readonly IExcelRepository _excelRepository;
    private readonly IArquivoService _arquivoService;   

    public RemessaService(IRemessaFactory remessaFactory, IExcelRepository excelRepository, IArquivoService arquivoService  )
    {
        _remessaFactory = remessaFactory;
        _excelRepository = excelRepository;
        _arquivoService = arquivoService;
    }


    public async Task<string> GerarRemessaAsync(LeituraExcelDTO excelRemessaDTO)
    {
        var dados = IdentificarBancoELayoutCNAB(excelRemessaDTO);
       
        var layout = _remessaFactory.IdentificarRemessaPorBancoELayout(dados.Banco, dados.Layout); // Factory
        var cnab = layout.CarregarLayoutEspecifico(dados); // A partir da escolha do Factory gera o Strategy para o banco e layout correspondente

        _arquivoService.ExportarArquivoTXT(cnab);

        return "Arquivo gerado com sucesso";
    }

    private ConfiguracaoRemessaDTO IdentificarBancoELayoutCNAB(LeituraExcelDTO excelRemessaDTO)
    {
        using var planilha = excelRemessaDTO.LayoutExcel.OpenReadStream();
        var dados = _excelRepository.LerPlanilha(planilha);

        return dados;
    }
}