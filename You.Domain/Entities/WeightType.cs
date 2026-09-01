namespace You.Domain.Entities;

public class WeightType
{
    public Guid WeightTypeId { get; set; }
    
    public string Name { get; set; } = string.Empty;
    public string? ImageKey { get; set; }
}