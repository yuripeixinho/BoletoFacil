using BoletoFacil.Application.DTOs.BoundedContexts.Itau.CNAB400;
using System.Text;

namespace BoletoFacil.Application.Strategies.CreateRemessa.BoundedContexts.Itau.CNAB400.Layouts;

public class StrategyHeaderItau400
{
    private readonly ItauHeader400DTO _h;

    public StrategyHeaderItau400(ItauHeader400DTO header) => _h = header;

    public string Gerar()
    {
        var sb = new StringBuilder(400);

        sb.Append("0");                                                     // 001-001 Tipo de registro
        sb.Append("1");                                                     // 002-002 Tipo de operação (Remessa)
        sb.Append("REMESSA".PadRight(7, ' '));                              // 003-009 Literal de remessa
        sb.Append("01");                                                    // 010-011 Código do serviço
        sb.Append("COBRANCA".PadRight(15, ' '));                            // 012-026 Literal de serviço
        sb.Append(_h.Agencia.PadLeft(4, '0'));                              // 027-030 Agência
        sb.Append("00");                                                    // 031-032 Zeros
        sb.Append(_h.Conta.PadLeft(5, '0'));                                // 033-037 Conta
        sb.Append(_h.DAC.PadLeft(1, '0'));                                  // 038-038 DAC
        sb.Append(new string(' ', 8));                                      // 039-046 Brancos
        sb.Append(_h.NomeEmpresa.PadRight(30, ' '));                        // 047-076 Nome da empresa
        sb.Append("341");                                                   // 077-079 Código do banco (Itaú)
        sb.Append("BANCO ITAU SA".PadRight(15, ' '));                       // 080-094 Nome do banco
        sb.Append(_h.DataGeracao.ToString("ddMMyy"));                       // 095-100 Data de geração (DDMMAA)
        sb.Append(new string(' ', 294));                                    // 101-394 Brancos
        sb.Append(_h.NumeroSequencialArquivo.PadLeft(6, '0'));              // 395-400 Número sequencial do registro

        string linha = sb.ToString();

        if (linha.Length != 400)
            throw new InvalidOperationException($"Header deve conter 400 posições. Atual: {linha.Length}");

        return linha;
    }
}
