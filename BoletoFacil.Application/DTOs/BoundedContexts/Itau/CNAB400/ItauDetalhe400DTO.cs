namespace BoletoFacil.Application.DTOs.BoundedContexts.Itau.CNAB400;

public class ItauDetalhe400DTO
{
    public string CodigoInscricaoId { get; set; }
    public string NumeroInscricao { get; set; }
    public string Agencia { get; set; }
    public string Conta { get; set; }
    public string DAC { get; set; }
    public string UsoEmpresa { get; set; }
    public string InstrucaoCancelamento { get; set; }
    public string NossoNumero { get; set; }
    public string QuantidadeMoeda => "0000000000000";
    public string NumeroCarteira { get; set; }
    public string UsoBanco { get; set; } 
    public string CodigoCarteira { get; set; }
    public string NumeroDocumento { get; set; }
    public DateTime DataVencimento { get; set; }
    public string ValorCobranca { get; set; }
    public string EspecieTitulo { get; set; }
    public string Instrucao1 { get; set; }
    public string Instrucao2 { get; set; }
    public string JurosMora { get; set; }
    public DateTime DataDesconto { get; set; }
    public string ValorDesconto { get; set; }
    public string CodigoInscricaoPagador { get; set; }
    public string NumeroInscricaoPagador { get; set; }
    public string Nome { get; set; }
    public string Logradouro { get; set; }
    public string Bairro { get; set; }
    public string CEP { get; set; }
    public string Cidade { get; set; }
    public string Estado { get; set; }
    public string NomeSacadorAvalista { get; set; }
    public DateTime DataMora { get; set; }
    public string PrazoDias { get; set; }
    public string NumeroSequencialArquivo { get; set; }
}
