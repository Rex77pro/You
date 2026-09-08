namespace You.Domain.Entities;

public class Exercise
{
    public Guid ExerciseId { get; set; }

    public string Name { get; set; } = string.Empty;
    public string? ImageKey { get; set; }
}

