namespace BoletoFacil.Application.Strategies.CreateRemessa.BoundedContexts;

public class BancoDoBrasilRemessaGenerator : IRemessaGenerator
{


    public string CarregarLayoutAsync()
    {
        return
              "001" +                         // Código do banco - fixo
              "00000" +                       // Lote - fixo
              " " +                            // Tipo de registro
              "BANCO DO BRASIL".PadRight(30, ' ') +
              DateTime.Now.ToString("ddMMyyyy") +
              "1044500000108300000".PadRight(50, ' ');
    }
}