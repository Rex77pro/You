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

    public async Task<Exercise> CreateExerciseAsync()
    {
        return null;
    }

    public async Task<List<Exercise>> GetAllAsync()
    {
        return null;
    }

    public async Task<Exercise> UpdateExercise()
    {
        return null;
    }
}