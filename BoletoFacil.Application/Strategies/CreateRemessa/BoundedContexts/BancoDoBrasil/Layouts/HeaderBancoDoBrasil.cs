namespace BoletoFacil.Application.Strategies.CreateRemessa.BoundedContexts.BancoDoBrasil.Layouts;

public class HeaderBancoDoBrasil
{
    //private readonly BBHeader240DTO _h;

    //public HeaderBancoDoBrasil(BBHeader240DTO header) => _h = header;

    //public string Gerar()
    //{
    //    var sb = new StringBuilder(240);

    //    sb.Append(_h.CodigoBanco.PadLeft(3, '0'));                      // 01-03
    //    sb.Append("0000");                                                 // 04-07 lote fixo
    //    sb.Append("0");                                                    // 08 tipo registro

    //    sb.Append(new string(' ', 9));                                     // 09-17 uso FEBRABAN
    //    sb.Append(_h.TipoInscricao);                                        // 18 tipo inscrição
    //    sb.Append(_h.Inscricao.PadLeft(14, '0'));                     // 19-32

    //    // Convênio
    //    sb.Append(_h.Convenio.PadRight(20, ' '));                            // 33-52

    //    sb.Append(_h.Agencia.PadLeft(5, '0'));                       // 53-57
    //    sb.Append(_h.DVAgencia.PadRight(1, ' '));                      // 58

    //    sb.Append(_h.Conta.PadLeft(12, '0'));                        // 59-70
    //    sb.Append(_h.DVConta.PadRight(1, ' '));                        // 71
    //    sb.Append(" ");                                                    // 72 DV ag/conta

    //    sb.Append(_h.NomeEmpresa.PadRight(30, ' '));                        // 73-102
    //    sb.Append("BANCO DO BRASIL S.A.".PadRight(30, ' '));                          // 103-132

    //    sb.Append(new string(' ', 10));                                    // 133-142 uso FEBRABAN
    //    sb.Append("1");                                                    // 143 código remessa

    //    sb.Append(_h.DataGeracao.ToString("ddMMyyyy"));                     // 144-151
    //    sb.Append(_h.DataGeracao.ToString(@"hhmmss"));                      // 152-157
    //    sb.Append(_h.NumeroSequencialArquivo.PadLeft(6, '0'));               // 158-163
    //    sb.Append("083");                         // 164-166
    //    sb.Append("01600".PadLeft(5, '0'));                                // 167-171 densidade

    //    sb.Append(new string(' ', 20));                                    // 172-191 reservado BB
    //    sb.Append(new string(' ', 20));                                    // 192-211 reservado empresa
    //    sb.Append(new string(' ', 29));                                     // 212-240 FEBRABAN

    //    string linha = sb.ToString();

    //    if (linha.Length != 240)
    //        throw new InvalidOperationException($"Header deve conter 240 posições. Atual: {linha.Length}");

    //    return sb.ToString();
    //}
}
