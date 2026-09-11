using You.Domain.Entities;

namespace You.Application.Interfaces.Repositories;

public interface IDayExerciseRepository
{
    Task<DayExercise> CreateDayExerciseAsync(DayExercise dayExercise);
    Task<List<DayExercise>> GetDayExerciseByDateAsync(DateOnly date);
    Task<List<DayExercise>> GetDayExerciseByDateRangeAsync(DateOnly dateFrom, DateOnly dateTo);
    Task<DayExercise> UpdateDayExerciseAsync(DayExercise dayExercise);
    Task DeleteDayExerciseAsync(DayExercise dayExercise);
}