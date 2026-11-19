using You.Domain.Entities;

namespace You.Application.Interfaces.Repositories;

public interface IExerciseVariantRepository
{
    Task<ExerciseVariant> CreateExerciseVariantAsync(ExerciseVariant exerciseVariant);
    Task<ExerciseVariant?> GetExerciseVariantAsync(Guid id);
    Task<ExerciseVariant?> GetExerciseVariantByCombinationAsync(Guid exerciseId, Guid? gripTypeId, Guid? weightTypeId);
    Task<IEnumerable<ExerciseVariant>> GetExerciseVariantsByExerciseAsync(Guid exerciseId);
    Task DeleteExerciseVariantAsync(ExerciseVariant exerciseVariant);
}

