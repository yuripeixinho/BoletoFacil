namespace BoletoFacil.Application.DTOs.Common;

public class RemessaDTO
{
    public string? Banco { get; set; } 
    public string? Layout { get; set; }  
    public string? Carteira { get; set; }
    public HeaderDTO? HeaderDTO { get; set; }   
    public List<DetalhesDTO>? DetalhesDTO { get; set; }
    public TrailerDTO? TrailerDTO { get; set; } = new TrailerDTO(); 
}
