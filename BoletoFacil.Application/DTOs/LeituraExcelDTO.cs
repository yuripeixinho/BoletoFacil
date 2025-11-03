using Microsoft.AspNetCore.Http;

namespace BoletoFacil.Application.DTOs;

public class LeituraExcelDTO
{
    public required IFormFile LayoutExcel { get; set; }
}