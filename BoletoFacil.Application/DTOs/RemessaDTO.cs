namespace BoletoFacil.Application.DTOs;

public class RemessaDTO
{
    public DateTime DataGeracao { get; set; } = DateTime.Now;
    public required string Banco { get; set; }
}
