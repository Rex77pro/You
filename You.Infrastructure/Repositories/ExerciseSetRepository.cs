using You.Domain.Entities;
using You.Infrastructure.Persistence;

namespace You.Infrastructure.Repositories;

public class ExerciseSetRepository
{
    private readonly YouDbContext _context;

    public ExerciseSetRepository(YouDbContext context)
    {
        _context = context;
    }

    public async Task<ExerciseSet> CreateExerciseSetAsync(ExerciseSet exerciseSet)
    {
        await _context.AddAsync(exerciseSet);
        await _context.SaveChangesAsync();
        return exerciseSet;
    }

    public async Task<ExerciseSet?> GetExerciseSetAsync(Guid id)
    {
        return await _context.ExerciseSets.FindAsync(id);
    }

    public async Task<ExerciseSet> UpdateExerciseSetAsync(Guid id, ExerciseSet updateVariables)
    {
        ExerciseSet? exerciseSet = await _context.ExerciseSets.FindAsync(id);

        if (exerciseSet == null)
        {
            throw new KeyNotFoundException($"Object key: {id}, not found.");
        }

        exerciseSet.SetNumber = updateVariables.SetNumber;
        exerciseSet.RepCount = updateVariables.RepCount;
        exerciseSet.Weight = updateVariables.Weight;
        exerciseSet.Duration = updateVariables.Duration;
        exerciseSet.Note = updateVariables.Note;

        await _context.SaveChangesAsync();
        return exerciseSet;
    }

    public async Task DeleteExerciseSetAsync(Guid id)
    {
        ExerciseSet? exerciseSet = await _context.ExerciseSets.FindAsync(id);

        if (exerciseSet == null)
        {
            throw new KeyNotFoundException($"Object key: {id}, not found.");
        }

        _context.Remove(exerciseSet);
        await _context.SaveChangesAsync();
    }
}