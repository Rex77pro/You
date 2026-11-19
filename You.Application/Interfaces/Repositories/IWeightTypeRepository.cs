using You.Domain.Entities;

namespace You.Application.Interfaces.Repositories;

public interface IWeightTypeRepository
{
    Task<WeightType> CreateWeightTypeAsync(WeightType weightType);
    Task<WeightType?> GetWeightTypeAsync(Guid id);
    Task<List<WeightType>> GetAllAsync();
    Task DeleteWeightTypeAsync(WeightType weightType);
}