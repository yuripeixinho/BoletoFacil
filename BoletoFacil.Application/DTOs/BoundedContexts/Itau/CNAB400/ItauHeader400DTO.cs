namespace BoletoFacil.Application.DTOs.BoundedContexts.Itau.CNAB400;

public class ItauHeader400DTO
{
    public required string Agencia { get; set; }
    public required string Conta { get; set; }
    public required string DAC { get; set; }
    public required string NomeEmpresa { get; set; }
    public required string NumeroSequencialArquivo { get; set; }
    public DateTime DataGeracao { get; set; } = DateTime.Now;
}
