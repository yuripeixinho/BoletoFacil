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


    // ANALISAR COM MAIS CAUITELA ESSA REGRA DE NEGOCIO

    // TODO:
    public string InstrucaoCancelamento { get; private set; }   // Deve ser preenchido na remessa somente quando utilizados, na posição 109-110, os códigos de ocorrência 
                                                    // 35 – Cancelamento de Instrução e 38 – Beneficiário não concorda com alegação do pagador.Para os
                                                    // demais códigos de ocorrência este campo deverá ser preenchido com zeros.
                                                    // Obs.: No arquivo retorno será informado o mesmo código da instrução cancelada, e para o cancelamento
                                                    // de alegação de pagador não há retorno da informação.
                                                    // TODO:

    // TODO:
    public string UsoEmpresa { get; private set; } // Campo não obrigatório, de livre utilização pela empresa, cuja informação não é consistida pelo Banco Itaú,
                                                    // e não sai no aviso de cobrança, retornando ao beneficiário no arquivo retorno em qualquer movimento 
                                                    // título(baixa, liquidação, confirmação de protesto, etc.) com o mesmo conteúdo da entrada.Para instituições
                                                    //financeiras (ag: 1248/Bancorp), o conteúdo deste campo também será impresso no rodapé do boleto.
    // TODO:
    public string NossoNumero { get; private set; } //Para carteiras com registro: 
                                                    // Escriturais: é enviado zerado pela empresa e retornado pelo Banco Itaú na confirmação de entrada,
                                                    // com exceção da carteira 115 e 138 cuja faixa de Nosso Número é de livre utilização pelo beneficiário
                                                    // seguindo as regras das carteiras Diretas abaixo;  

                                                    // Diretas: é de livre utilização pelo beneficiário, não podendo ser repetida se o número ainda estiver
                                                    // registrado no Banco Itaú ou se transcorridos menos de 45 dias de sua baixa / liquidação no Banco Itaú.
                                                    // Dependendo da carteira de cobrança utilizada a faixa de Nosso Número pode ser definida pelo Banco.
                                                    // Para todas as movimentações envolvendo o título, o “Nosso Número” deve ser informado.

                                                    // Para carteiras sem registro: 
                                                    // Normalmente a empresa define o “Nosso Número” e é responsável pelo seu controle e pelo cálculo do 
                                                    // DAC – Dígito de Auto conferência (Vide Nota 23).

    public Detalhe() // usado apenas por EF e AutoMapper
    { }


    public Detalhe(int detalheId, int codigoInscricaoId, string numeroInscricao, string agencia, string conta, string dac, string instrucaoCancelamento, string usoEmpresa, string nossoNumero)
    {
        DetalheId = detalheId;
        CodigoInscricaoId = codigoInscricaoId;
        NumeroInscricao = numeroInscricao;
        Agencia = agencia;
        Conta = conta;
        DAC = dac;
        InstrucaoCancelamento = instrucaoCancelamento;
        UsoEmpresa = usoEmpresa;
        NossoNumero = nossoNumero;

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
    }
}