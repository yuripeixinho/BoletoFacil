using BoletoFacil.Application.DTOs.Common;
using BoletoFacil.Application.Interfaces.Services;

namespace BoletoFacil.Application.Services;

public class UsoEmpresaService : IUsoEmpresaService
{
    public string GerarUsoEmpresa(string sequencial)
    {
        string data = DateTime.Now.ToString("yyMMdd");

        string baseNum = data + sequencial;
        int dv = CalcularModulo10(baseNum);

        return $"{baseNum}{dv}";
    }

    private int CalcularModulo10(string numero)
    {
        int soma = 0;
        int peso = 2;

        // Percorre da direita para esquerda
        for (int i = numero.Length - 1; i >= 0; i--)
        {
            int n = numero[i] - '0';
            int temp = n * peso;

            if (temp > 9)
                temp = (temp / 10) + (temp % 10);

            soma += temp;

            peso = (peso == 2) ? 1 : 2;
        }

        int resto = soma % 10;
        return (resto == 0) ? 0 : (10 - resto);
    }
}
