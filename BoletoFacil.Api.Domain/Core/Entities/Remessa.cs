using BoletoFacil.Domain.Core.Enums;

namespace BoletoFacil.Domain.Core.Entities;

public class Remessa : Entity
{
    public DateTime DataGeracao { get; set; } = DateTime.Now;
    public Banco Banco { get; set; }
}
