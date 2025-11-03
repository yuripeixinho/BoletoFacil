namespace BoletoFacil.Domain.Core.Entities;

public class Remessa : Entity
{
    public int NumeroSequencialArquivo { get; set; }
    public string? NomeArquivo { get; set; }
    public DateTime DataGeracao { get; set; } = DateTime.Now;

    public required CedenteConta CedenteConta { get; set; }
    public required Guid CedenteContaId { get; set; }
}
