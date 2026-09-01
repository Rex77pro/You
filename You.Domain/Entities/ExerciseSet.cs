namespace You.Domain.Entities;

public class ExerciseSet
{
    public Guid ExerciseSetId { get; set; }

    public Guid DayExerciseId { get; set; }
    public DayExercise? DayExercise { get; set; }

    public int SetNumber { get; set; }
    
    public int? RepCount { get; set; }
    public decimal? Weight { get; set; }
    public TimeSpan? Duration { get; set; }

    public string? Note { get; set; }
}
