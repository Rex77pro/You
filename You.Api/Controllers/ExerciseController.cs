using Microsoft.AspNetCore.Mvc;
using You.Application.Interfaces.Services;
using You.Domain.Entities;

namespace You.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExerciseController : ControllerBase
{
    private readonly IExerciseService _iExerciseService;
    public ExerciseController(IExerciseService iExerciseService)
    {
        _iExerciseService = iExerciseService;
    }

    [HttpGet()]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult<List<Exercise>>> GetAll()
    {
        List<Exercise> result = await _iExerciseService.GetAllAsync();

        if (result.Count < 0)
        {
            return NoContent();
        }

        return Ok(result);
    }
}