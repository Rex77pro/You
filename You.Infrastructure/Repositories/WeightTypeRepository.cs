using Microsoft.EntityFrameworkCore;
using You.Application.Interfaces.Repositories;
using You.Domain.Entities;
using You.Infrastructure.Persistence;

namespace You.Infrastructure.Repositories;

public class WeightTypeRepository : IWeightTypeRepository
{
    private readonly YouDbContext _context;

    public WeightTypeRepository(YouDbContext context)
    {
        _context = context;
    }

    public async Task<WeightType> CreateWeightTypeAsync(WeightType weightType)
    {
        await _context.WeightTypes.AddAsync(weightType);
        await _context.SaveChangesAsync();
        return weightType;
    }

    public async Task<List<WeightType>> GetAllAsync()
    {
        return await _context.WeightTypes.ToListAsync();
    }

    public async Task DeleteWeightTypeAsync(WeightType weightType)
    {
        _context.WeightTypes.Remove(weightType);
        await _context.SaveChangesAsync();
    }
}
