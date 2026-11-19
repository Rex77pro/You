using You.Domain.Entities;

namespace You.Application.Interfaces.Services;

public interface IExerciseService
{
    Task<Exercise> CreateExerciseAsync(Exercise exercise);
    Task<Exercise?> GetExerciseAsync(Guid id);
    Task<List<Exercise>> GetAllAsync();
    Task<Exercise> UpdateExerciseAsync(Guid id, Exercise updateVariables);
    Task DeleteExerciseAsync(Guid id);
}