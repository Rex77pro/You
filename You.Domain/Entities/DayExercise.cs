namespace You.Domain.Entities;

public class DayExercise
{
    public Guid DayExerciseId { get; set; }

    public Guid ExerciseVariantId { get; set; }
    public ExerciseVariant? ExerciseVariant { get; set; }

    public DateOnly Date { get; set; }
    public int ExerciseOrder { get; set; }

    public ICollection<ExerciseSet> Sets { get; set; } = [];
}

