using You.Application.Interfaces.Repositories;
using You.Application.Interfaces.Services;
using You.Application.Validators;
using You.Domain.Entities;

namespace You.Application.Services;

public class GripTypeService : IGripTypeService
{
    private readonly IGripTypeRepository _repo;

    public GripTypeService(IGripTypeRepository repo)
    {
        _repo = repo;
    }

    public async Task<GripType> CreateGripTypeAsync(GripType gripType)
    {
        if (string.IsNullOrWhiteSpace(gripType.Name))
        {
            throw new ArgumentException("Grip type name must not be null or whitespace.", nameof(gripType.Name));
        }

        ImageKeyValidator.Validate(gripType.ImageKey);

        return await _repo.CreateGripTypeAsync(gripType);
    }

    public async Task<GripType?> GetGripTypeAsync(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("Grip type id must not be empty.", nameof(id));
        }

        var gripType = await _repo.GetGripTypeAsync(id);

        if (gripType == null)
        {
            throw new KeyNotFoundException($"Object key: {id}, not found.");
        }

        return gripType;
    }

    public async Task<List<GripType>> GetAllAsync()
    {
        return await _repo.GetAllAsync();
    }

    public async Task DeleteGripTypeAsync(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("Grip type id must not be empty.", nameof(id));
        }

        var gripType = await _repo.GetGripTypeAsync(id);

        if (gripType == null)
        {
            throw new KeyNotFoundException($"Object key: {id}, not found.");
        }

        await _repo.DeleteGripTypeAsync(gripType);
    }
}