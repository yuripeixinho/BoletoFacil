namespace BoletoFacil.Domain.Core.Entities;

public class Cedente
{
    public Guid CedenteID { get; set; } 
    public required string NomeEmpresa { get; set; }
    public string TipoInscricao { get; set; } = null!;
    public string Inscricao { get; set; } = null!;
    public required CedenteConta CedenteConta { get; set; }
    public required Guid CedenteContaID { get; set; }
}
