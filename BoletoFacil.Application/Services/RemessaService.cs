using AutoMapper;
using BoletoFacil.Application.DTOs.Common;
using BoletoFacil.Application.Factories.Interfaces;
using BoletoFacil.Application.Interfaces.Repositories;
using BoletoFacil.Application.Interfaces.Services;
using BoletoFacil.Application.Validation.Business;
using BoletoFacil.Domain.Core.Entities.Common;
using System.Linq;
using System.Runtime.ConstrainedExecution;

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
        // ler e identificar baseado na planilha
        var dados = IdentificarBancoELayoutCNAB(excelRemessaDTO);
        await _validator.ValidarAsync(dados);

        // regras de negócio
        ObterRegrasNegocioPorBanco(dados);
        await _remessaBusinessValidator.ValidarGeracaoRemessaAsync(dados);

        // factory para carregar o layout
        var layout = _remessaFactory.IdentificarRemessaPorBancoELayout(dados.Banco, dados.Layout); // Factory
        var cnab = layout.CarregarLayoutEspecifico(dados); // A partir da escolha do Factory gera o Strategy para o banco e layout correspondente

        // mapear informações DTO para persistência na base de dados (entidades)

        var header = new Header(
            agencia: dados.HeaderDTO.Agencia,
            conta: dados.HeaderDTO.Conta,
            DAC: dados.HeaderDTO.DAC,
            nomeEmpresa: dados.HeaderDTO.NomeEmpresa,
            numeroSequencialArquivo: dados.HeaderDTO.NumeroSequencialArquivo
        );

        var detalhes = dados.DetalhesDTO
            .Select(d => new Detalhe(
                detalheId: 0,
                codigoInscricaoId: d.CodigoInscricaoId,
                numeroInscricao: d.NumeroInscricao,
                agencia: d.Agencia,
                conta: d.Conta,
                DAC: d.DAC,
                instrucaoCancelamento: d.InstrucaoCancelamento,
                usoEmpresa: d.UsoEmpresa,
                nossoNumero: d.NossoNumero,
                numeroCarteira: d.NumeroCarteira,
                dataVencimento: d.DataVencimento,
                valorCobranca: d.ValorCobranca,
                instrucao1: d.Instrucao1,
                instrucao2: d.Instrucao2,
                dataDesconto: d.DataDesconto,
                valorDesconto:  d.ValorDesconto,
                nome: d.Nome,
                logradouro: d.Logradouro,
                bairro: d.Bairro,
                CEP: d.CEP,
                cidade: d.Cidade,
                estado: d.Estado,
                nomeSacadorAvalista: d.Nome,
                numeroSequencialArquivo: d.NumeroSequencialArquivo  
            ))
            .ToList();

        var remessaEntity = new Remessa(
            bancoId: int.Parse(dados.Banco),
            header: header,
            detalhes: detalhes
        );

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
    
    private void ObterRegrasNegocioPorBanco(RemessaDTO dados)
    {
        var regras = _regrasCNABFactory.ObterRegras(dados.Banco, dados.Layout);

        regras.Aplicar(dados);
    }
}