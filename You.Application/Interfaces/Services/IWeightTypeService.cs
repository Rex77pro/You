using You.Domain.Entities;

namespace You.Application.Interfaces.Services;

public interface IWeightTypeServices
{
    Task<WeightType> CreateWeightTypeAsync(WeightType weightType);
    Task<List<WeightType>> GetAllAsync();
    Task DeleteWeightTypeAsync(Guid id);
}