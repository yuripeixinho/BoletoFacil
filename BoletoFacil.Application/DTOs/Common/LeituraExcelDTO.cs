using Microsoft.AspNetCore.Http;

namespace BoletoFacil.Application.DTOs.Common;

public class LeituraExcelDTO
{
    public required IFormFile LayoutExcel { get; set; }
}