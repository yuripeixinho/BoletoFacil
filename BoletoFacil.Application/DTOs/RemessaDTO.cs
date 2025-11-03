namespace BoletoFacil.Application.DTOs;

public class RemessaDTO
{
    public BBHeader240DTO? Header { get; set; }
    //public required IEnumerable<DetalheDTO> Detalhe { get; set; }   
    //public required TrailerDTO Trailer { get; set; }
    public LeituraExcelDTO? CnabExcel { get; set; }
}


