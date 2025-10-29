using Microsoft.AspNetCore.Mvc;

namespace BoletoFacil.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RemessaController : ControllerBase
{
    public RemessaController()
    {
        
    }

    [HttpPost]
    public async Task<IActionResult> GerarRemessa([FromBody] Remessa remessa)
    {

    }
}
