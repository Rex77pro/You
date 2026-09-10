using Microsoft.EntityFrameworkCore;
using You.Domain.Entities;
using You.Infrastructure.Persistence;

namespace You.Infrastructure.Repositories;

public class DayExerciseRepository
{
    private readonly YouDbContext _context;

    public DayExerciseRepository(YouDbContext context)
    {
        _context = context;
    }

    public async Task<DayExercise> CreateDayExerciseAsync(DayExercise dayExercise)
    {
        await _context.AddAsync(dayExercise);
        await _context.SaveChangesAsync();
        return dayExercise;
    }

    public async Task<List<DayExercise>> GetDayExerciseByDateAsync(DateOnly date)
    {
        return await _context.DayExercises.Where(
            x => x.Date == date
        )
        .ToListAsync();
    }

    public async Task<List<DayExercise>> GetDayExerciseByDateRangeAsync(DateOnly dateFrom, DateOnly dateTo)
    {
        return await _context.DayExercises.Where(
            x => x.Date >= dateFrom && x.Date <= dateTo
        )
        .ToListAsync();
    }
    public async Task<DayExercise> UpdateDayExerciseAsync(Guid id, DayExercise updateVariables)
    {
        DayExercise? dayExercise = await _context.DayExercises.FindAsync(id);

        if (dayExercise == null)
        {
            throw new KeyNotFoundException($"Object key: {id}, not found");
        }

        dayExercise.Date = updateVariables.Date;
        dayExercise.ExerciseOrder = updateVariables.ExerciseOrder;

        await _context.SaveChangesAsync();
        return dayExercise;
    }

    public async Task DeleteDayExerciseAsync(Guid id)
    {
        DayExercise? dayExercise = await _context.DayExercises.FindAsync(id);

        if (dayExercise == null)
        {
            throw new KeyNotFoundException($"Object key: {id}, not found");
        }

        _context.Remove(dayExercise);
        await _context.SaveChangesAsync();
    }

}