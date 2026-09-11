using Microsoft.EntityFrameworkCore;
using You.Application.Interfaces.Repositories;
using You.Domain.Entities;
using You.Infrastructure.Persistence;

namespace You.Infrastructure.Repositories;

public class ExerciseRepository : IExerciseRepository
{
    private readonly YouDbContext _context;

    public ExerciseRepository(YouDbContext context)
    {
        _context = context;
    }

    public async Task<Exercise> CreateExerciseAsync(Exercise exercise)
    {
        await _context.Exercises.AddAsync(exercise);
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

    public async Task<Exercise> UpdateExerciseAsync(Exercise exercise)
    {
        await _context.SaveChangesAsync();
        return exercise;
    }

    public async Task DeleteExerciseAsync(Exercise exercise)
    {
        _context.Exercises.Remove(exercise);
        await _context.SaveChangesAsync();
    }

    
}