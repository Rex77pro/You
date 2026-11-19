using You.Application.Interfaces.Repositories;
using You.Application.Interfaces.Services;
using You.Domain.Entities;

namespace You.Application.Services;

public class DayExerciseService : IDayExerciseService
{
    private readonly IDayExerciseRepository _dayRepo;
    private readonly IExerciseVariantService _varService;

    public DayExerciseService(IDayExerciseRepository dayRepo, IExerciseVariantService varService)
    {
        _dayRepo = dayRepo;
        _varService = varService;
    }

    public async Task<DayExercise> CreateDayExerciseAsync(DayExercise dayExercise)
    {
        if (dayExercise.Date == default)
        {
            throw new ArgumentException("Date must be specified.", nameof(dayExercise.Date));
        }

        if (dayExercise.ExerciseOrder < 1)
        {
            throw new ArgumentException("Exercise order must be at least 1", nameof(dayExercise.ExerciseOrder));
        }

        if (dayExercise.ExerciseVariant == null)
        {
            throw new ArgumentException(
                "Exercise variant must be specified.",
                nameof(dayExercise.ExerciseVariant));
        }

        var variant = await _varService.GetOrCreateExerciseVariantAsync(
            dayExercise.ExerciseVariant.ExerciseId,
            dayExercise.ExerciseVariant.GripTypeId,
            dayExercise.ExerciseVariant.WeightTypeId);

        dayExercise.ExerciseVariantId = variant.ExerciseVariantId;
        dayExercise.ExerciseVariant = variant;

        return await _dayRepo.CreateDayExerciseAsync(dayExercise);
    }

    public async Task<DayExercise> GetDayExerciseByIdAsync(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("Exercise id must not be empty.", nameof(id));
        }

        var dayExercise = await _dayRepo.GetDayExerciseByIdAsync(id);

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
        return await _dayRepo.GetDayExerciseByDateAsync(date);
    }

    public async Task<List<DayExercise>> GetDayExerciseByDateRangeAsync(DateOnly dateFrom, DateOnly dateTo)
    { 
        if (dateFrom > dateTo)
        {
            throw new ArgumentException("Date from cannot be later that date to", nameof(dateFrom));
        }

        return await _dayRepo.GetDayExerciseByDateRangeAsync(dateFrom, dateTo);
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

        if (updateVariables.ExerciseVariant == null)
        {
            throw new ArgumentException(
                "Exercise variant must be specified.",
                nameof(updateVariables.ExerciseVariant));
        }
        
        var dayExercise = await _dayRepo.GetDayExerciseByIdAsync(id);

        if (dayExercise == null)
        {
            throw new KeyNotFoundException($"Object key: {id}, not found.");
        }

        var variant = await _varService.GetOrCreateExerciseVariantAsync(
            updateVariables.ExerciseVariant.ExerciseId,
            updateVariables.ExerciseVariant.GripTypeId,
            updateVariables.ExerciseVariant.WeightTypeId);
        
        dayExercise.Date = updateVariables.Date;
        dayExercise.ExerciseOrder = updateVariables.ExerciseOrder;

        dayExercise.ExerciseVariantId = variant.ExerciseVariantId;
        dayExercise.ExerciseVariant = variant;

        return await _dayRepo.UpdateDayExerciseAsync(dayExercise);
    }

    public async Task DeleteDayExerciseAsync(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("Day exercise id must not be empty.", nameof(id));
        }

        var dayExercise = await _dayRepo.GetDayExerciseByIdAsync(id);

        if (dayExercise == null)
        {
            throw new KeyNotFoundException($"Object key: {id}, not found.");
        }

        await _dayRepo.DeleteDayExerciseAsync(dayExercise);
    }
}