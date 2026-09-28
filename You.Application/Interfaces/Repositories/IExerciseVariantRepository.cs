using You.Domain.Entities;

namespace You.Application.Interfaces.Repositories;

public interface IExerciseVariantRepository
{
    Task<ExerciseVariant> CreateExerciseVariantAsync(ExerciseVariant exerciseVariant);
    Task<ExerciseVariant?> GetExerciseVariantAsync(Guid id);
    Task<IEnumerable<ExerciseVariant>> GetExerciseVariantsByExerciseAsync(Guid exerciseId);
    Task DeleteExerciseVariantAsync(ExerciseVariant exerciseVariant);
}

