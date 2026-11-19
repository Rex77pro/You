using You.Application.Interfaces.Repositories;
using You.Application.Interfaces.Services;
using You.Application.Validators;
using You.Domain.Entities;

namespace You.Application.Services;

public class WeightTypeService : IWeightTypeServices
{
    private readonly IWeightTypeRepository _repo;

    public WeightTypeService(IWeightTypeRepository repo)
    {
        _repo = repo;
    }

    public async Task<WeightType> CreateWeightTypeAsync(WeightType weightType)
    {
        if (string.IsNullOrWhiteSpace(weightType.Name))
        {
            throw new ArgumentException("Weight type name must not be null or whitespace.", nameof(weightType.Name));
        }

        ImageKeyValidator.Validate(weightType.ImageKey);

        return await _repo.CreateWeightTypeAsync(weightType);
    }

    public async Task<WeightType?> GetWeightTypeAsync(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("Weight type id must not be empty.", nameof(id));
        }

        var weightType = await _repo.GetWeightTypeAsync(id);

        if (weightType == null)
        {
            throw new KeyNotFoundException($"Object key: {id}, not found.");
        }

        return weightType;
    }

    public async Task<List<WeightType>> GetAllAsync()
    {
        return await _repo.GetAllAsync();
    }    

    public async Task DeleteWeightTypeAsync(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("Weight type id must not be empty.", nameof(id));
        }

        var weightType = await _repo.GetWeightTypeAsync(id);

        if (weightType == null)
        {
            throw new KeyNotFoundException($"Object key: {id}, not found.");
        }

        await _repo.DeleteWeightTypeAsync(weightType);
    }
}