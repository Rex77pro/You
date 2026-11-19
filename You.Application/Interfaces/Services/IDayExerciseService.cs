using You.Domain.Entities;

namespace You.Application.Interfaces.Services;

public interface IDayExerciseService
{
    Task<DayExercise> CreateDayExerciseAsync(DayExercise dayExercise);
    Task<DayExercise> GetDayExerciseByIdAsync(Guid id);
    Task<List<DayExercise>> GetDayExerciseByDateAsync(DateOnly date);
    Task<List<DayExercise>> GetDayExerciseByDateRangeAsync(DateOnly dateFrom, DateOnly dateTo);
    Task<DayExercise> UpdateDayExerciseAsync(Guid id, DayExercise updateVariables);
    Task DeleteDayExerciseAsync(Guid id);
}