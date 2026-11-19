using You.Domain.Entities;

namespace You.Application.Interfaces.Services;

public interface IExerciseSetService
{
    Task<ExerciseSet> CreateExerciseSetAsync(ExerciseSet exerciseSet);
    Task<ExerciseSet?> GetExerciseSetAsync(Guid id);
    Task<List<ExerciseSet>> GetExerciseSetsByDayExerciseIdAsync(Guid dayExerciseId);
    Task<ExerciseSet> UpdateExerciseSetAsync(Guid id, ExerciseSet updateVariables);
    Task DeleteExerciseSetAsync(Guid id);
}