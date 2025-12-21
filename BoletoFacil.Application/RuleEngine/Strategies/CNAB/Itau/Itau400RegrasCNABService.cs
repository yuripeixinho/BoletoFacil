using BoletoFacil.Application.DTOs.BoundedContexts.Itau;
using BoletoFacil.Application.DTOs.Common;
using BoletoFacil.Application.RuleEngine.Strategies.CNAB.Base;
using BoletoFacil.Domain.Core.Exceptions;

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
    
    public string GerarCodigoCarteira(string carteira)
    {
        if (!int.TryParse(carteira, out var carteiraInt))
            throw new Exception("Não foi possível converter a carteira pra int");

        var codigoCarteira = CarteirasItauConfig.GerarCodigoCarteira(carteiraInt);

        return codigoCarteira;
    }

    public string GerarNumeroDocumento(string numeroSequencial)
    {
        // 1. Normaliza para 9 dígitos (zeros à esquerda)
        string numero = numeroSequencial.PadLeft(9, '0');

        int soma = 0;
        int multiplicador = 2;

        // 2. Percorre da direita para esquerda aplicando pesos 2 e 1 alternados
        for (int i = numero.Length - 1; i >= 0; i--)
        {
            int digito = numero[i] - '0';
            int produto = digito * multiplicador;

            // Soma individual dos dígitos do produto
            soma += (produto > 9) ? (produto - 9) : produto;

            // Alterna multiplicador 2 → 1 → 2
            multiplicador = multiplicador == 2 ? 1 : 2;
        }

        // 3. Calcula o DAC
        int resto = soma % 10;
        int dac = (resto == 0) ? 0 : (10 - resto);

        // 4. Retorna o número completo (8 dígitos + DAC)
        return numero + dac;
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

    public string GerarPrazoDias(string instrucao1, string instrucao2, string prazoDias)
    {
        int prazoDiasInformado = int.Parse(prazoDias);
        
        var instrucoes = new[] { instrucao1, instrucao2 };

        var instrucoesComPrazo = new HashSet<string>
        {
            "34", // Protesto após XX dias corridos
            "35", // Protesto após XX dias úteis
            "39", // Não receber após XX dias
            "66", // Negativação expressa
            "95", // Não receber após XX dias
            "96"  // Devolver após XX dias
        };

        var instrucaoExigePrazo = instrucoes.Any(i => instrucoesComPrazo.Contains(i));

        if (!instrucaoExigePrazo)
            return "00";

        // Caso especial: instrução 39
        if (instrucoes.Contains("39") && (prazoDiasInformado == 0))
            return "00";

        if (prazoDiasInformado < 0 || prazoDiasInformado > 99)
            throw new DomainException("Prazo inválido. Informe um valor entre 1 e 99 dias.");

        return prazoDiasInformado.ToString("D2");
    }
    

    public void Aplicar(RemessaDTO remessa)
    {
        GerarNumeroSequencialArquivo(remessa);
        
        foreach (var detalhe in remessa.DetalhesDTO)
        {
            detalhe.UsoEmpresa = GerarUsoEmpresa(detalhe.NumeroSequencialArquivo);
            detalhe.NossoNumero = GerarNossoNumero(detalhe.NumeroCarteira, detalhe.NumeroSequencialArquivo);
            detalhe.CodigoCarteira = GerarCodigoCarteira(detalhe.NumeroCarteira);
            detalhe.NumeroDocumento = GerarNumeroDocumento(detalhe.NumeroSequencialArquivo);
            detalhe.PrazoDias = GerarPrazoDias(detalhe.Instrucao1, detalhe.Instrucao2, detalhe.PrazoDias);
        }
    }
}
