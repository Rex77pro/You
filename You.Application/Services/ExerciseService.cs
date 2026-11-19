using You.Application.Interfaces.Repositories;
using You.Application.Interfaces.Services;
using You.Application.Validators;
using You.Domain.Entities;

namespace You.Application.Services;

public class ExerciseService : IExerciseService
{
    private readonly IExerciseRepository _repo;

    public ExerciseService(IExerciseRepository repo)
    {
        _repo = repo;
    }

    public async Task<Exercise> CreateExerciseAsync(Exercise exercise)
    {
        if (string.IsNullOrWhiteSpace(exercise.Name))
        {
            throw new ArgumentException("Exercise name must not be null or whitespace.", nameof(exercise.Name));
        }

        ImageKeyValidator.Validate(exercise.ImageKey);

        return await _repo.CreateExerciseAsync(exercise);
    }

    public async Task<Exercise?> GetExerciseAsync(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("Exercise id must not be empty.", nameof(id));
        }

        var exercise = await _repo.GetExerciseAsync(id);

        if (exercise == null)
        {
            throw new KeyNotFoundException($"Object key: {id}, not found.");
        }
        
        return exercise;
    }

    public async Task<List<Exercise>> GetAllAsync()
    {
        return await _repo.GetAllAsync();
    }

    public async Task<Exercise> UpdateExerciseAsync(Guid id, Exercise updateVariables)
    {
        var exercise = await _repo.GetExerciseAsync(id);

        if (exercise == null)
        {
            throw new KeyNotFoundException($"Object key: {id}, not found.");
        }

        if (string.IsNullOrWhiteSpace(updateVariables.Name))
        {
            throw new ArgumentException("Exercise name must not be null or whitespace.", nameof(updateVariables.Name));
        }

        ImageKeyValidator.Validate(updateVariables.ImageKey);

        exercise.Name = updateVariables.Name;
        exercise.ImageKey = updateVariables.ImageKey;

        return await _repo.UpdateExerciseAsync(exercise);
    }

    public async Task DeleteExerciseAsync(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("Exercise id must not be empty.", nameof(id));
        }

        var exercise = await _repo.GetExerciseAsync(id);

        if (exercise == null)
        {
            throw new KeyNotFoundException($"Object key: {id}, not found");
        }

        await _repo.DeleteExerciseAsync(exercise);
    }
}

