using You.Application.Interfaces.Repositories;
using You.Application.Interfaces.Services;
using You.Domain.Entities;

namespace You.Application.Services;

public class ExerciseVariantService : IExerciseVariantService
{
    private readonly IExerciseVariantRepository _variantRepo;
    private readonly IExerciseRepository _exerciseRepo;
    private readonly IGripTypeRepository _gripRepo;
    private readonly IWeightTypeRepository _weightRepo;
    public ExerciseVariantService(
        IExerciseVariantRepository variantRepo,
        IExerciseRepository exerciseRepo,
        IGripTypeRepository gripRepo,
        IWeightTypeRepository weightRepo)
    {
        _variantRepo = variantRepo;
        _exerciseRepo = exerciseRepo;
        _gripRepo = gripRepo;
        _weightRepo = weightRepo;
    }
    
    public async Task<ExerciseVariant> GetOrCreateExerciseVariantAsync(
        Guid exerciseId, 
        Guid? gripTypeId, 
        Guid? weightTypeId)
    {
        var exercise = await _exerciseRepo.GetExerciseAsync(exerciseId);

        if (exercise == null)
        {
            throw new ArgumentException($"Object key: {exerciseId}, not found.");
        }

        if (gripTypeId.HasValue)
        {
            var gripType = await _gripRepo.GetGripTypeAsync(gripTypeId.Value);

            if (gripType == null)
            {
                throw new ArgumentException($"Object key: {gripTypeId}, not found.");
            }
        }

        if (weightTypeId.HasValue)
        {
            var weightType = await _weightRepo.GetWeightTypeAsync(weightTypeId.Value);

            if (weightType == null)
            {
                throw new ArgumentException($"Object key: {weightTypeId}, not found.");
            }
        }

        var variant = await _variantRepo.GetExerciseVariantByCombinationAsync(
            exerciseId, 
            gripTypeId, 
            weightTypeId);

        if (variant != null)
        {
            return variant;
        }

        variant = new ExerciseVariant()
        {
            ExerciseId = exerciseId,
            GripTypeId = gripTypeId,
            WeightTypeId = weightTypeId
        };

        return await _variantRepo.CreateExerciseVariantAsync(variant);
    }
}