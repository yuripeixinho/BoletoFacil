namespace BoletoFacil.Domain.Core.Entities;

public class CedenteConta
{
    public Guid CedenteContaID { get; set; }    
    public string CodigoBanco { get; set; } = null!;
    public string Agencia { get; set; } = null!;
    public string? DVAgencia { get; set; }
    public string Conta { get; set; } = null!;
    public string? DVConta { get; set; }
    public string? Convenio { get; set; }

    public Guid CedenteID { get; set; }
    public required Cedente Cedente { get; set; }
    public Remessa? Remessa { get; set; }
}