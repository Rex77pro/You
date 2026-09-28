using Microsoft.EntityFrameworkCore;
using You.Application.Interfaces.Repositories;
using You.Domain.Entities;
using You.Infrastructure.Persistence;

namespace You.Infrastructure.Repositories;

public class ExerciseVariantRepository : IExerciseVariantRepository
{
    private readonly YouDbContext _context;

    public ExerciseVariantRepository(YouDbContext context)
    {
        _context = context;
    }

    public async Task<ExerciseVariant> CreateExerciseVariantAsync(ExerciseVariant exerciseVariant)
    {
        await _context.ExerciseVariants.AddAsync(exerciseVariant);
        await _context.SaveChangesAsync();
        return exerciseVariant;
    }

    public async Task<ExerciseVariant?> GetExerciseVariantAsync(Guid id)
    {
        return await _context.ExerciseVariants
            .FirstOrDefaultAsync(x => 
                x.ExerciseVariantId == id);
    }

    public async Task<IEnumerable<ExerciseVariant>> GetExerciseVariantsByExerciseAsync(Guid exerciseId)
    {
        return await _context.ExerciseVariants
            .Where(x => 
                x.ExerciseId == exerciseId)
            .ToListAsync();
    }

    public async Task DeleteExerciseVariantAsync(ExerciseVariant exerciseVariant)
    {
        _context.ExerciseVariants.Remove(exerciseVariant);
        await _context.SaveChangesAsync();
    }
}