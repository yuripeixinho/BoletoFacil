using BoletoFacil.Application.DTOs;
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

    public async Task<string> GerarRemessaAsync(LeituraExcelDTO ExcelRemessaDTO)
    {
        using var stream = ExcelRemessaDTO.LayoutExcel.OpenReadStream();
        var dadosRemessa = await _excelRepository.ReadExcelAsync(stream);

        var layout = _remessaFactory.CriarRemessaParaOBanco(dadosRemessa.Header.CodigoBanco);
        var cnab = layout.CarregarLayout(dadosRemessa); // a partir do strategy cria o CNAB

         _arquivoService.ExportarArquivoTXT(cnab);

        return "Arquivo gerado com sucesso";
    }
}