using Microsoft.EntityFrameworkCore;
using You.Domain.Entities;
using You.Infrastructure.Persistence;

namespace You.Infrastructure.Repositories;

public class GripTypeRepository
{
    private readonly YouDbContext _context;

    public GripTypeRepository(YouDbContext context)
    {
        _context = context;
    }

    public async Task<GripType> CreateGripTypeAsync(GripType gripType)
    {
        await _context.AddAsync(gripType);
        await _context.SaveChangesAsync();
        return gripType;
    }

    public async Task<List<GripType>> GetAllAsync()
    {
        return await _context.GripTypes.ToListAsync();
    }

    public async Task DeleteGripTypeAsync(Guid id)
    {
        GripType? gripType = await _context.GripTypes.FindAsync(id);

        if (gripType == null)
        {
            throw new KeyNotFoundException($"Object id: {id}, not found.");
        }

        _context.Remove(gripType);
        await _context.SaveChangesAsync();
    }
}

