using Microsoft.AspNetCore.Mvc;
using TestAPBD.Services;

namespace TestAPBD.Controllers;

[Route("api/professors")]
[ApiController]
public class ProfessorsController(IAppDbService appDbService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetProfessors([FromQuery] string? lastName)
    {
        var result = await appDbService.GetProfessorsAsync(lastName);
        return Ok(result);
    }
}