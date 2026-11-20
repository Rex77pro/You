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

    [HttpPost()]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Exercise>> CreateExercise([FromBody]Exercise request)
    {        
        var exercise = await _iExerciseService.CreateExerciseAsync(request);

        return CreatedAtAction(
            nameof(GetById),
            new { id = exercise.ExerciseId },
            exercise);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<Exercise>> GetById(Guid id)
    {
        var result = await _iExerciseService.GetExerciseAsync(id);

        return Ok(result);
    }

    [HttpGet()]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<Exercise>>> GetAll()
    {
        List<Exercise> result = await _iExerciseService.GetAllAsync();

        return Ok(result);
    }


    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<Exercise>> UpdateExercise(Guid id, Exercise request)
    {
        var result = await _iExerciseService.UpdateExerciseAsync(id, request);


        return Ok(result);
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeleteExercise(Guid id)
    {
        await _iExerciseService.DeleteExerciseAsync(id);

        return NoContent();
    }

}