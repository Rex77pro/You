namespace You.Domain.Entities;

public class Exercise
{
    public Guid ExerciseId { get; set; }

    public Guid? GripTypeId { get; set; }
    public GripType? GripType { get; set; }

    public Guid? WeightTypeId { get; set; }
    public WeightType? WeightType { get; set; }

    public string Name { get; set; } = string.Empty;
    public string? ImageKey { get; set; }
}

