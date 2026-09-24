using You.Application.Interfaces.Repositories;
using You.Application.Interfaces.Services;
using You.Domain.Entities;

namespace You.Application.Services;

public class DayExerciseService : IDayExerciseService
{
    private readonly IDayExerciseRepository _repo;

    public DayExerciseService(IDayExerciseRepository repo)
    {
        _repo = repo;
    }

    public async Task<DayExercise> CreateDayExerciseAsync(DayExercise dayExercise)
    {
        if (dayExercise.ExerciseVariantId == Guid.Empty)
        {
            throw new ArgumentException("Exercise variant id must not be empty.",
                nameof(dayExercise.ExerciseVariantId));
        }

        if (dayExercise.Date == default)
        {
            throw new ArgumentException("Date must be specified.", nameof(dayExercise.Date));
        }

        if (dayExercise.ExerciseOrder < 1)
        {
            throw new ArgumentException("Exercise order must be at least 1", nameof(dayExercise.ExerciseOrder));
        }

        return await _repo.CreateDayExerciseAsync(dayExercise);
    }

    public async Task<DayExercise> GetDayExerciseByIdAsync(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("Exercise id must not be empty.", nameof(id));
        }

        var dayExercise = await _repo.GetDayExerciseByIdAsync(id);

        if (dayExercise == null)
        {
            throw new KeyNotFoundException($"Object key: {id}, not found.");
        }

        return dayExercise;
    }

    public async Task<List<DayExercise>> GetDayExerciseByDateAsync(DateOnly date)
    {
        if (date == default)
        {
            throw new ArgumentException("Date must be specified.", nameof(date));
        }
        return await _repo.GetDayExerciseByDateAsync(date);
    }

    public async Task<List<DayExercise>> GetDayExerciseByDateRangeAsync(DateOnly dateFrom, DateOnly dateTo)
    { 
        if (dateFrom > dateTo)
        {
            throw new ArgumentException("Date from cannot be later that date to", nameof(dateFrom));
        }

        return await _repo.GetDayExerciseByDateRangeAsync(dateFrom, dateTo);
    }

    public async Task<DayExercise> UpdateDayExerciseAsync(Guid id, DayExercise updateVariables)
    {
        if (updateVariables.Date == default)
        {
            throw new ArgumentException("Date must be specified.", nameof(updateVariables.Date));
        }

        if (updateVariables.ExerciseOrder < 1)
        {
            throw new ArgumentException("Exercise order must be at least 1", nameof(updateVariables.ExerciseOrder));
        }
        
        var dayExercise = await _repo.GetDayExerciseByIdAsync(id);

        if (dayExercise == null)
        {
            throw new KeyNotFoundException($"Object key: {id}, not found.");
        }

        dayExercise.Date = updateVariables.Date;
        dayExercise.ExerciseOrder = updateVariables.ExerciseOrder;

        return await _repo.UpdateDayExerciseAsync(dayExercise);
    }

    public async Task DeleteDayExerciseAsync(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("Day exercise id must not be empty.", nameof(id));
        }

        var dayExercise = await _repo.GetDayExerciseByIdAsync(id);

        if (dayExercise == null)
        {
            throw new KeyNotFoundException($"Object key: {id}, not found.");
        }

        await _repo.DeleteDayExerciseAsync(dayExercise);
    }
}