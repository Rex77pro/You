namespace You.Domain.Entities;

public class DayExercise
{
    public Guid DayExerciseId { get; set; }

    public Guid ExerciseId { get; set; }
    public Exercise? Exercise { get; set; }

    public DateOnly Date { get; set; }
    public int ExerciseOrder { get; set; }

    public ICollection<ExerciseSet> Sets { get; set; } = [];
}

