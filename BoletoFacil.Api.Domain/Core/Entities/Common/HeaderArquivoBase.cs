namespace BoletoFacil.Domain.Core.Entities.Common;

public abstract class HeaderArquivoBase
{
    public Guid HeaderId { get; set; }
    public required string CodigoBanco { get; set; }
    public required string Agencia { get; set; }
    public required string Conta { get; set; }
    public required string DAC { get; set; }
    public required string NomeEmpresa { get; set; }
}
