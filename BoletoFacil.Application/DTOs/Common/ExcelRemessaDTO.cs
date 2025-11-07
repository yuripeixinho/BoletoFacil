using Microsoft.AspNetCore.Http;

namespace BoletoFacil.Application.DTOs.Common;

public class ExcelRemessaDTO
{
    public required IFormFile LayoutExcel { get; set; }
}