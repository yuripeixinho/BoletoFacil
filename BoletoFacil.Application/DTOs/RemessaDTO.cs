using BoletoFacil.Domain.Core.Enums;

namespace BoletoFacil.Application.DTOs;

public class RemessaDTO
{
    public DateTime DataGeracao { get; set; } = DateTime.Now;
    public Banco Banco { get; set; }
}
