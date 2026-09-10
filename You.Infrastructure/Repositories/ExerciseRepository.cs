using Microsoft.EntityFrameworkCore;
using You.Domain.Entities;
using You.Infrastructure.Persistence;

namespace You.Infrastructure.Repositories;

public class ExerciseRepository
{
    private readonly YouDbContext _context;

    public ExerciseRepository(YouDbContext context)
    {
        _context = context;
    }

    public async Task<Exercise> CreateExerciseAsync(Exercise exercise)
    {
        await _context.AddAsync(exercise);
        await _context.SaveChangesAsync();
        return exercise;
    }

    public async Task<Exercise?> GetExerciseAsync(Guid id)
    {
        return await _context.Exercises.FindAsync(id);
    }

    public async Task<List<Exercise>> GetAllAsync()
    {   
        return await _context.Exercises.ToListAsync();
    }

    public async Task<Exercise> UpdateExerciseAsync(Guid id, Exercise updateVariables)
    {
        Exercise? exercise = await _context.Exercises.FindAsync(id);

        if (exercise == null)
        {
            throw new KeyNotFoundException($"Object key: {id}, not found.");
        }

        exercise.Name = updateVariables.Name;
        exercise.ImageKey = updateVariables.ImageKey;

        await _context.SaveChangesAsync();
        return exercise;
    }

    public async Task DeleteExerciseAsync(Guid id)
    {
        Exercise? exercise = await _context.Exercises.FindAsync(id);

        if (exercise == null)
        {
            throw new KeyNotFoundException($"Object key: {id}, not found");
        }

        _context.Remove(exercise);
        await _context.SaveChangesAsync();
    }
}