using BoletoFacil.Application.DTOs.BoundedContexts.Itau;
using BoletoFacil.Application.DTOs.Common;
using BoletoFacil.Application.RuleEngine.Strategies.CNAB.Base;

namespace BoletoFacil.Application.RuleEngine.Strategies.CNAB.Itau;

public class Itau400RegrasCNABService : IRegraCNABService
{
    public void GerarNumeroSequencialArquivo(RemessaDTO remessa)
    {
        var sequencial = 1;

        remessa.HeaderDTO.NumeroSequencialArquivo = sequencial.ToString("D6");
        sequencial++;

        foreach (var detalhe in remessa.DetalhesDTO)
        {
            detalhe.NumeroSequencialArquivo = sequencial.ToString("D6");
            sequencial++;
        }

   
        //remessa.TrailerDTO.NumeroSequencialArquivo = sequencial.ToString("D6");
    }

    public string GerarUsoEmpresa(string sequencial)
    {
        string data = DateTime.Now.ToString("yyMMdd");

        string baseNum = data + sequencial;
        int dv = CalcularDAC(baseNum);

        return $"{baseNum}{dv}";
    }

    public string GerarNossoNumero(string carteira, string numeroSequencial)
    {
        if (!CarteirasItauConfig.DevoGerarNossoNumero(carteira))
            return "00000000"; // ajuste tamanho conforme seu layout

        var dac = CalcularDAC(numeroSequencial);      
        return numeroSequencial + dac;
    }

    // analisar se esse calculo é igual para os demais bancos, se for o caso, colocar em funcao utils/helpers
    private int CalcularDAC(string numero)
    {
        int soma = 0;
        int peso = 2;

        // Percorre da direita para esquerda
        for (int i = numero.Length - 1; i >= 0; i--)
        {
            int n = numero[i] - '0';
            int temp = n * peso;

            if (temp > 9)
                temp = temp / 10 + temp % 10;

            soma += temp;

            peso = peso == 2 ? 1 : 2;
        }

        int resto = soma % 10;
        return resto == 0 ? 0 : 10 - resto;
    }

    public void Aplicar(RemessaDTO remessa)
    {
        GerarNumeroSequencialArquivo(remessa);
        
        foreach (var detalhe in remessa.DetalhesDTO)
        {
            detalhe.UsoEmpresa = GerarUsoEmpresa(detalhe.NumeroSequencialArquivo);
            detalhe.NossoNumero = GerarNossoNumero(remessa.Carteira, detalhe.NumeroSequencialArquivo);
        }

    }
}
