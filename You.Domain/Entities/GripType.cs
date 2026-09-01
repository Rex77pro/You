namespace You.Domain.Entities;

public class GripType
{
    public Guid GripTypeId { get; set; }
    
    public string Name { get; set; } = string.Empty;
    public string? ImageKey { get; set; }
}