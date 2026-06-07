using Microsoft.AspNetCore.Mvc;
using TestAPBD.DTOs;
using TestAPBD.Exceptions;
using TestAPBD.Services;

namespace TestAPBD.Controllers;

[Route("api/courses")]
[ApiController]
public class CoursesController(IAppDbService appDbService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> AddCourse([FromBody] AddCourseDto dto)
    {
        try
        {
            await appDbService.AddCourseAsync(dto);
            return Created();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
}