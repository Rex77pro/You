using You.Domain.Entities;

namespace You.Application.Interfaces.Repositories;

public interface IExerciseSetRepository
{
    Task<ExerciseSet> CreateExerciseSetAsync(ExerciseSet exerciseSet);
    Task<ExerciseSet?> GetExerciseSetAsync(Guid id);
    Task<List<ExerciseSet>> GetExerciseSetsByDayExerciseIdAsync(Guid dayExerciseId);
    Task<ExerciseSet> UpdateExerciseSetAsync(ExerciseSet exerciseSet);
    Task DeleteExerciseSetAsync(ExerciseSet exerciseSet);
}