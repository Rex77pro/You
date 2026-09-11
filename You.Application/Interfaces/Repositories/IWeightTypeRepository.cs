using You.Domain.Entities;

namespace You.Application.Interfaces.Repositories;

public interface IWeightTypeRepository
{
    Task<WeightType> CreateWeightTypeAsync(WeightType weightType);
    Task<List<WeightType>> GetAllAsync();
    Task DeleteWeightTypeAsync(WeightType weightType);
}