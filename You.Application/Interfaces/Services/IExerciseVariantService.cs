using You.Domain.Entities;

namespace You.Application.Interfaces.Services;

public interface IExerciseVariantService
{
    Task<ExerciseVariant> GetOrCreateExerciseVariantAsync(
        Guid exerciseId, 
        Guid? gripTypeId, 
        Guid? weightTypeId);
}