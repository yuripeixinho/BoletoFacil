using BoletoFacil.Domain.Core.Exceptions;
using System.Text.RegularExpressions;

namespace BoletoFacil.Domain.Core.Entities.Common;

public class Header
{
    public int HeaderId { get; private set; }
    public string Agencia { get; private set; }
    public string Conta { get; private set; }
    public string DAC { get; private set; }
    public string NomeEmpresa { get; private set; }

    public string NumeroSequencialArquivo { get; private set; }

    public Guid RemessaId { get; private set; }
    public Remessa Remessa { get; set; }


    public Header(string agencia, string conta, string DAC, string nomeEmpresa, string numeroSequencialArquivo)
    {
        Agencia = agencia;  
        Conta = conta;
        this.DAC = DAC;
        NomeEmpresa = nomeEmpresa;
        NumeroSequencialArquivo = numeroSequencialArquivo;

        ValidarDominio();
    }

    public void ValidarDominio()
    {
        if (string.IsNullOrWhiteSpace(Agencia))
            throw new DomainException("Não é possível criar um header sem agência definida.");
        if (!Regex.IsMatch(Agencia, @"^\d{4}$"))
            throw new DomainException("A agência deve possuir exatamente 4 dígitos numéricos.");

        if (string.IsNullOrWhiteSpace(Conta))
            throw new DomainException("O header deve conter uma conta bancária associada.");
        if (!Regex.IsMatch(Conta, @"^\d{5,10}$"))
            throw new DomainException("A conta bancária informada possui formato inválido.");

        if (string.IsNullOrWhiteSpace(DAC))
            throw new DomainException("O header deve possuir um dígito verificador (DAC) para a conta.");
        if (!Regex.IsMatch(DAC, @"^[A-Z0-9]{1}$"))
            throw new DomainException("O dígito verificador (DAC) deve conter apenas um caractere alfanumérico.");

        if (string.IsNullOrWhiteSpace(NomeEmpresa))
            throw new DomainException("O header precisa conter o nome da empresa remetente.");
        if (NomeEmpresa.Length > 30)
            throw new DomainException("O nome da empresa excede o limite permitido de 30 caracteres.");
    }
}
