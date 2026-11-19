using You.Domain.Entities;

namespace You.Application.Interfaces.Services;

public interface IWeightTypeServices
{
    Task<WeightType> CreateWeightTypeAsync(WeightType weightType);
    Task<WeightType?> GetWeightTypeAsync(Guid id);
    Task<List<WeightType>> GetAllAsync();
    Task DeleteWeightTypeAsync(Guid id);
}