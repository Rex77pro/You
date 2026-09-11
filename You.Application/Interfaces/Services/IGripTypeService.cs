using You.Domain.Entities;

namespace You.Application.Interfaces.Services;

public interface IGripTypeService
{
    Task<GripType> CreateGripTypeAsync(GripType gripType);
    Task<List<GripType>> GetAllAsync();
    Task DeleteGripTypeAsync(Guid id);
}