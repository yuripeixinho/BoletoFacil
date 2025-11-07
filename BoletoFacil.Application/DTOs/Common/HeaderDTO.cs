namespace BoletoFacil.Application.DTOs.Common;

public class HeaderDTO
{
    public required string Agencia { get; set; }
    public required string Conta { get; set; }
    public required string DAC { get; set; }
    public required string NomeEmpresa { get; set; }
    public required string NumeroSequencialArquivo { get; set; }
    public DateTime DataGeracao { get; set; } = DateTime.Now;
}