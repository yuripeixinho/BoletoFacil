using BoletoFacil.Application.DTOs.BoundedContexts.Itau.CNAB400;
using BoletoFacil.Application.DTOs.Common;
using BoletoFacil.Application.Strategies.CreateRemessa.BoundedContexts.Itau.CNAB400.Layouts;
using System.Text;

namespace BoletoFacil.Application.Strategies.CreateRemessa.BoundedContexts.Itau.CNAB400;

public class BancoItauRemessaGenerator400 : IRemessaGenerator
{
    public string CarregarLayoutEspecifico(ConfiguracaoRemessaDTO remessaDTO)
    {
        var sb = new StringBuilder();

        var headerItau = new ItauHeader400DTO
        {
            CodigoBanco = remessaDTO.HeaderDTO.CodigoBanco,
            TipoInscricao = remessaDTO.HeaderDTO.TipoInscricao,
            Inscricao = remessaDTO.HeaderDTO.Inscricao,
            Convenio = remessaDTO.HeaderDTO.Convenio,
            Agencia = remessaDTO.HeaderDTO.Agencia,
            DVAgencia = remessaDTO.HeaderDTO.DVAgencia,
            Conta = remessaDTO.HeaderDTO.Conta,
            DVConta = remessaDTO.HeaderDTO.DVConta,
            NomeEmpresa = remessaDTO.HeaderDTO.NomeEmpresa,
            NumeroSequencialArquivo = remessaDTO.HeaderDTO.NumeroSequencialArquivo
        };

        var header = new StrategyHeaderItau400(headerItau).Gerar();
        sb.AppendLine(header);

        //var detalhes = new DetalheBancoDoBrasil(dto).Gerar();
        //var trailer = new TrailerBancoDoBrasil(dto).Gerar();

        return sb.ToString();
    }
}