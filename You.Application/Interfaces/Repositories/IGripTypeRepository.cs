using You.Domain.Entities;

namespace You.Application.Interfaces.Repositories;

public interface IGripTypeRepository
{
    Task<GripType> CreateGripTypeAsync(GripType gripType);
    Task<GripType?> GetGripTypeAsync(Guid id);
    Task<List<GripType>> GetAllAsync();
    Task DeleteGripTypeAsync(GripType gripType);
}

