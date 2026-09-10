using Microsoft.EntityFrameworkCore;
using You.Domain.Entities;
using You.Infrastructure.Persistence;

namespace You.Infrastructure.Repositories;

public class WeightTypeRepository
{
    private readonly YouDbContext _context;

    public WeightTypeRepository(YouDbContext context)
    {
        _context = context;
    }

    public async Task<WeightType> CreateWeightTypeAsync(WeightType weightType)
    {
        await _context.AddAsync(weightType);
        await _context.SaveChangesAsync();
        return weightType;
    }

    public async Task<List<WeightType>> GetAllAsync()
    {
        return await _context.WeightTypes.ToListAsync();
    }

    public async Task DeleteWeightTypeAsync(Guid id)
    {
        WeightType? weightType = await _context.WeightTypes.FindAsync(id);

        if (weightType == null)
        {
            throw new KeyNotFoundException($"Object id: {id}, not found.");
        }

        _context.Remove(weightType);
        await _context.SaveChangesAsync();
    }
}
