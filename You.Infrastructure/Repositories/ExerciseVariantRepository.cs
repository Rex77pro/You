using Microsoft.EntityFrameworkCore;
using Npgsql;
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
        try
        {
            await _context.SaveChangesAsync();
            return exerciseVariant;
        }
        catch (DbUpdateException ex) when (
            ex.InnerException is PostgresException postgres &&
            postgres.SqlState == PostgresErrorCodes.UniqueViolation &&
            postgres.ConstraintName ==
                "IX_ExerciseVariants_ExerciseId_GripTypeId_WeightTypeId")
        {
            _context.Entry(exerciseVariant).State = EntityState.Detached;

            var existingVariant =
                await GetExerciseVariantByCombinationAsync(
                    exerciseVariant.ExerciseId,
                    exerciseVariant.GripTypeId,
                    exerciseVariant.WeightTypeId);
            
            if (existingVariant is null)
            {
                throw;
            }

            return existingVariant;
        }
    }

    public async Task<ExerciseVariant?> GetExerciseVariantAsync(Guid id)
    {
        return await _context.ExerciseVariants
            .Include(x => x.Exercise)
            .Include(x => x.GripType)
            .Include(x => x.WeightType)
            .FirstOrDefaultAsync(x => x.ExerciseVariantId == id);
    }

    public async Task<ExerciseVariant?> GetExerciseVariantByCombinationAsync(
        Guid exerciseId, 
        Guid? gripTypeId, 
        Guid? weightTypeId)
    {
        return await _context.ExerciseVariants
            .Where(x => 
                x.ExerciseId == exerciseId &&
                x.GripTypeId == gripTypeId &&
                x.WeightTypeId == weightTypeId)
            .Include(x => x.Exercise)
            .Include(x => x.GripType)
            .Include(x => x.WeightType)
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<ExerciseVariant>> GetExerciseVariantsByExerciseAsync(Guid exerciseId)
    {
        return await _context.ExerciseVariants
            .Include(x => x.Exercise)
            .Include(x => x.GripType)
            .Include(x => x.WeightType)
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