namespace BoletoFacil.Domain.Core.Entities.Common;

public abstract class RemessaBase 
{
    public int RemessaId { get; set; } 
    public DateTime DataGeracao { get; set; } = DateTime.Now;
}
