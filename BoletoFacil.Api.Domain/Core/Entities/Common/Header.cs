namespace BoletoFacil.Domain.Core.Entities.Common;

public class Header
{
    public Guid HeaderId { get; set; }
    public required string Agencia { get; set; }
    public required string Conta { get; set; }
    public required string DAC { get; set; }
    public required string NomeEmpresa { get; set; }
    public required string NumeroSequencialArquivo { get; set; }
}
