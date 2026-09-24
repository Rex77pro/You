using Microsoft.EntityFrameworkCore;
using You.Application.Interfaces.Repositories;
using You.Domain.Entities;
using You.Infrastructure.Persistence;

namespace You.Infrastructure.Repositories;

public class ExerciseSetRepository : IExerciseSetRepository
{
    private readonly YouDbContext _context;

    public ExerciseSetRepository(YouDbContext context)
    {
        _context = context;
    }

    public async Task<ExerciseSet> CreateExerciseSetAsync(ExerciseSet exerciseSet)
    {
        await _context.ExerciseSets.AddAsync(exerciseSet);
        await _context.SaveChangesAsync();
        return exerciseSet;
    }

    public async Task<ExerciseSet?> GetExerciseSetAsync(Guid id)
    {
        return await _context.ExerciseSets.FindAsync(id);
    }

    public async Task<List<ExerciseSet>> GetExerciseSetsByDayExerciseIdAsync(Guid dayExerciseId)
    {
        return await _context.ExerciseSets
                .Where(x => x.DayExerciseId == dayExerciseId)
                .OrderBy(x => x.SetNumber)
                .ToListAsync();
    }

    public async Task<ExerciseSet> UpdateExerciseSetAsync(ExerciseSet exerciseSet)
    {
        await _context.SaveChangesAsync();
        return exerciseSet;
    }

    public async Task DeleteExerciseSetAsync(ExerciseSet exerciseSet)
    {
        _context.ExerciseSets.Remove(exerciseSet);
        await _context.SaveChangesAsync();
    }
}