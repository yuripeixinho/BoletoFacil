using BoletoFacil.Domain.Core.Entities.Dimension;
using BoletoFacil.Domain.Core.Exceptions;
using System.Text.RegularExpressions;

namespace BoletoFacil.Domain.Core.Entities.Common;

public class Detalhe
{
    public int DetalheId { get; private set; }

    public DimCodigoInscricao DimCodigoInscricao { get; private set; }
    public int CodigoInscricaoId { get; private set; }

    public string NumeroInscricao { get; private set; }
    public string Agencia { get; private set; }
    public string Conta { get; private set; }
    public string DAC { get; private set; }

    public string InstrucaoCancelamento { get; private set; }

    public string UsoEmpresa { get; private set; }
    public string NossoNumero { get; private set; }


    public string NumeroCarteira { get; private set; }
    public DateTime DataVencimento { get; private set; }
    public decimal ValorCobranca { get; private set; }
    public string Instrucao1 { get; private set; }
    public string Instrucao2 { get; private set; }
    public DateTime? DataDesconto { get; private set; }
    public decimal ValorDesconto { get; private set; }
    public string Nome { get; private set; }
    public string Logradouro { get; private set; }
    public string Bairro { get; private set; }
    public string CEP { get; private set; }
    public string Cidade { get; private set; }
    public string Estado { get; private set; }
    public string NomeSacadorAvalista { get; private set; }
    public string NumeroSequencialArquivo { get; private set; }

    public Guid RemessaId { get; private set; }
    public Remessa Remessa { get; set; }


    public Detalhe( int detalheId, int codigoInscricaoId, string numeroInscricao, string agencia, string conta, string DAC, string instrucaoCancelamento,
                    string usoEmpresa, string nossoNumero, string numeroCarteira, DateTime dataVencimento, decimal valorCobranca, string instrucao1, string instrucao2, 
                    DateTime? dataDesconto, decimal valorDesconto, string nome, string logradouro, string bairro, string CEP, string cidade, string estado, 
                    string nomeSacadorAvalista, string numeroSequencialArquivo)
    {
        DetalheId = detalheId;
        CodigoInscricaoId = codigoInscricaoId;
        NumeroInscricao = numeroInscricao;
        Agencia = agencia;
        Conta = conta;
        this.DAC = DAC;
        InstrucaoCancelamento = instrucaoCancelamento;
        UsoEmpresa = usoEmpresa;
        NossoNumero = nossoNumero;
        NumeroCarteira = numeroCarteira;
        DataVencimento = dataVencimento;
        ValorCobranca = valorCobranca;
        Instrucao1 = instrucao1;
        Instrucao2 = instrucao2;
        DataDesconto = dataDesconto;
        Nome = nome;
        Logradouro = logradouro;
        Bairro = bairro;
        this.CEP = CEP;
        Cidade = cidade;
        Estado = estado;
        NomeSacadorAvalista = nomeSacadorAvalista;
        NumeroSequencialArquivo = numeroSequencialArquivo;
    }

    public void ValidarDominio()
    {
        if (string.IsNullOrWhiteSpace(Agencia))
            throw new DomainException("Não é possível criar um detalhe sem agência definida.");
        if (!Regex.IsMatch(Agencia, @"^\d{4}$"))
            throw new DomainException("A agência deve possuir exatamente 4 dígitos numéricos.");

        if (string.IsNullOrWhiteSpace(Conta))
            throw new DomainException("O detalhe deve conter uma conta bancária associada.");

        if (string.IsNullOrWhiteSpace(DAC))
            throw new DomainException("O detalhe deve possuir um dígito verificador (DAC) para a conta.");
        if (!Regex.IsMatch(DAC, @"^[A-Z0-9]{1}$"))
            throw new DomainException("O dígito verificador (DAC) deve conter apenas um caractere alfanumérico.");

        if (DataVencimento <= DateTime.Today)
            throw new DomainException("A data de vencimento não pode ser menor que a data atual.");
    }

    public void ValidarDesconto(decimal valorDesconto)
    {
        if (valorDesconto < 0)
            throw new DomainException("O valor do desconto não pode ser negativo.");

        if (valorDesconto > ValorCobranca)
            throw new DomainException("O desconto não pode ser maior que o valor do título.");

        if (valorDesconto > ValorCobranca * 0.9m)
            throw new DomainException("O desconto não pode ultrapassar 90% do valor do título.");

        if (DataDesconto >= DataVencimento)
            throw new DomainException("A data de desconto deve ser anterior à data de vencimento.");
    }
}