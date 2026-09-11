using Microsoft.EntityFrameworkCore;
using You.Application.Interfaces.Repositories;
using You.Domain.Entities;
using You.Infrastructure.Persistence;

namespace You.Infrastructure.Repositories;

public class DayExerciseRepository : IDayExerciseRepository
{
    private readonly YouDbContext _context;

    public DayExerciseRepository(YouDbContext context)
    {
        _context = context;
    }

    public async Task<DayExercise> CreateDayExerciseAsync(DayExercise dayExercise)
    {
        await _context.DayExercises.AddAsync(dayExercise);
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
    public async Task<DayExercise> UpdateDayExerciseAsync(DayExercise dayExercise)
    {
        await _context.SaveChangesAsync();
        return dayExercise;
    }

    public async Task DeleteDayExerciseAsync(DayExercise dayExercise)
    {
        _context.DayExercises.Remove(dayExercise);
        await _context.SaveChangesAsync();
    }

}