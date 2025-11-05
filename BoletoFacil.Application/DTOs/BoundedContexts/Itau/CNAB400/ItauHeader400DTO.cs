namespace BoletoFacil.Application.DTOs.BoundedContexts.Itau.CNAB400;

public class ItauHeader400DTO
{
    public required string CodigoBanco { get; set; }
    public required string TipoInscricao { get; set; }
    public required string Inscricao { get; set; }
    public required string Convenio { get; set; }
    public required string Agencia { get; set; }
    public required string DVAgencia { get; set; }
    public required string Conta { get; set; }
    public required string DVConta { get; set; }
    public required string NomeEmpresa { get; set; }
    public required string NumeroSequencialArquivo { get; set; }
    public DateTime DataGeracao { get; set; } = DateTime.Now;
}
