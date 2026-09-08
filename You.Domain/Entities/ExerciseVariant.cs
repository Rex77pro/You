namespace You.Domain.Entities;

public class ExerciseVariant
{ 
    public Guid ExerciseVariantId { get; set; }

    public ICollection<DayExercise> DayExercises { get; set; } = [];

    public Guid ExerciseId { get; set; }
    public Exercise Exercise { get; set; } = null;

    public Guid? GripTypeId { get; set; }
    public GripType? GripType { get; set; }

    public Guid? WeightTypeId { get; set; }
    public WeightType? WeightType { get; set; }
}