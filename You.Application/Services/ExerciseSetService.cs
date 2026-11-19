using You.Application.Interfaces.Repositories;
using You.Application.Interfaces.Services;
using You.Domain.Entities;

namespace You.Application.Services;

public class ExerciseSetService : IExerciseSetService
{
    private readonly IExerciseSetRepository _repo;

    public ExerciseSetService(IExerciseSetRepository repo)
    {
        _repo = repo;
    }

    public async Task<ExerciseSet> CreateExerciseSetAsync(ExerciseSet exerciseSet)
    {
        if (exerciseSet.DayExerciseId == Guid.Empty)
        {
            throw new ArgumentException("Day exercise id must not be empty.", nameof(exerciseSet.DayExerciseId));
        }

        if (exerciseSet.SetNumber < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(exerciseSet.SetNumber), exerciseSet.SetNumber, "Set number must be at least 1.");
        }

        if (exerciseSet.RepCount < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(exerciseSet.RepCount), exerciseSet.RepCount, "Repetition must be at least 1.");
        }

        if (exerciseSet.Weight < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(exerciseSet.Weight), exerciseSet.Weight, "Weight cannot be negative.");
        }

        if (exerciseSet.Weight is decimal weight && decimal.Round(weight, 2) != weight)
        {
            throw new ArgumentException("Weight cannot contain more that 2 decimal", nameof(exerciseSet.Weight));
        }

        if (exerciseSet.Note != null)
        {
            if (exerciseSet.Note.Length > 500)
            {
                throw new ArgumentException("Note cannot exceed 500 characters.", nameof(exerciseSet.Note));
            }
        }
        
        var dayExercise = new DayExercise()
        {
            Date = DateOnly.FromDateTime(DateTime.Now),
            ExerciseOrder = 1,
            ExerciseVariantId = new Guid()
        };

        var newExerciseSet = new ExerciseSet
        {
            SetNumber = 1,
            RepCount = exerciseSet.RepCount,
            Weight = exerciseSet.Weight,
            Duration = exerciseSet.Duration,
            Note = exerciseSet.Note,
            DayExercise = dayExercise
        };

        dayExercise.Sets.Add(newExerciseSet);

        return await _repo.CreateExerciseSetAsync(newExerciseSet);
    }

    public async Task<ExerciseSet?> GetExerciseSetAsync(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("Exercise set id must not be empty.", nameof(id));
        }

        var exerciseSet = await _repo.GetExerciseSetAsync(id);

        if (exerciseSet == null)
        {
            throw new KeyNotFoundException($"Object key: {id}, not found.");
        }
        
        return exerciseSet;
    }

    public async Task<List<ExerciseSet>> GetExerciseSetsByDayExerciseIdAsync(Guid dayExerciseId)
    {
        return await _repo.GetExerciseSetsByDayExerciseIdAsync(dayExerciseId);
    }

    public async Task<ExerciseSet> UpdateExerciseSetAsync(Guid id, ExerciseSet updateVariables)
    {
        var exerciseSet = await _repo.GetExerciseSetAsync(id);

        if (exerciseSet == null)
        {
            throw new KeyNotFoundException($"Object key: {id}, not found.");
        }

        if (updateVariables.SetNumber < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(updateVariables.SetNumber), updateVariables.SetNumber, "Set number must be at least 1.");
        }

        if (updateVariables.RepCount < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(updateVariables.RepCount), updateVariables.RepCount, "Repetition must be at least 1.");
        }

        if (updateVariables.Weight < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(updateVariables.Weight), updateVariables.Weight, "Weight cannot be negative.");
        }

        if (updateVariables.Weight is decimal weight && decimal.Round(weight, 2) != weight)
        {
            throw new ArgumentException("Weight cannot contain more that 2 decimal", nameof(updateVariables.Weight));
        }

        if (updateVariables.Note != null )
        {
            if (updateVariables.Note.Length > 500)
            {
                throw new ArgumentException("Note cannot exceed 500 characters.", nameof(updateVariables.Note));   
            }
        }

        exerciseSet.SetNumber = updateVariables.SetNumber;
        exerciseSet.RepCount = updateVariables.RepCount;
        exerciseSet.Weight = updateVariables.Weight;
        exerciseSet.Duration = updateVariables.Duration;
        exerciseSet.Note = updateVariables.Note;

        return await _repo.UpdateExerciseSetAsync(exerciseSet);
    }

    public async Task DeleteExerciseSetAsync(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("Exercise id must not be empty.", nameof(id));
        }

        var exerciseSet = await _repo.GetExerciseSetAsync(id);

        if (exerciseSet == null)
        {
            throw new KeyNotFoundException($"Object key: {id}, not found.");
        }

        await _repo.DeleteExerciseSetAsync(exerciseSet);
    }
}