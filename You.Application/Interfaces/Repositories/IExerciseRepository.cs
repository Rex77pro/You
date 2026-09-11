using You.Domain.Entities;

namespace You.Application.Interfaces.Repositories;

public interface IExerciseRepository
{
    Task<Exercise> CreateExerciseAsync(Exercise exercise);
    Task<Exercise?> GetExerciseAsync(Guid id);
    Task<List<Exercise>> GetAllAsync();
    Task<Exercise> UpdateExerciseAsync(Exercise exercise);
    Task DeleteExerciseAsync(Exercise exercise);
}

