using BoletoFacil.Application.DTOs.BoundedContexts.Itau.CNAB400;
using System.Text;

namespace BoletoFacil.Application.Strategies.CreateRemessa.BoundedContexts.Itau.CNAB400.Layouts;

public class StrategyDetalhesItau400
{
    private readonly ItauDetalhe400DTO _d;

    public StrategyDetalhesItau400(ItauDetalhe400DTO detalhes)
    {
        _d = detalhes;  
    }

    public string Gerar()
    {
        var sb = new StringBuilder(400);

        sb.Append("1");                                                           // 001     001     Tipo de Registro = 1 (Detalhe)
        sb.Append(_d.CodigoInscricaoId.PadLeft(2, '0'));                          // 002     003     Tipo de Inscrição (01=CPF, 02=CNPJ)
        sb.Append(_d.NumeroInscricao.PadLeft(14, '0'));                          // 004     017     Número de Inscrição (CPF/CNPJ)
        sb.Append(_d.Agencia.PadLeft(4, '0'));                                   // 018     021     Agência
        sb.Append("00");                                                          // 022     023     Complemento = "00"
        sb.Append(_d.Conta.PadLeft(5, '0'));                                     // 024     028     Conta Corrente
        sb.Append(_d.DAC.PadLeft(1, '0'));                                       // 029     029     DAC da Conta
        sb.Append("".PadRight(4, ' '));                                         // 030     033     Brancos
        sb.Append(_d.Instrucao.PadLeft(4, '0'));                                 // 034     037     Código de Instrução/Alegação
        sb.Append(_d.UsoEmpresa.PadRight(25, ' '));                             // 038     062     Uso da Empresa (identificação do título)
        sb.Append(_d.NossoNumero.PadLeft(8, '0'));                              // 063     070     Nosso Número
        sb.Append(_d.QuantidadeMoeda.PadLeft(13, '0'));                          // 071     083     QTD Moeda
        sb.Append(_d.Carteira.PadLeft(3, '0'));                            // 084     086     Número da Carteira


        string linha = sb.ToString();

        //if (linha.Length != 400)
        //    throw new InvalidOperationException($"Detalhe deve conter 400 posições. Atual: {linha.Length}");

        return linha;
    }
}
