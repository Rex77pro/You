using Microsoft.EntityFrameworkCore;
using You.Application.Interfaces.Repositories;
using You.Domain.Entities;
using You.Infrastructure.Persistence;

namespace You.Infrastructure.Repositories;

public class GripTypeRepository : IGripTypeRepository
{
    private readonly YouDbContext _context;

    public GripTypeRepository(YouDbContext context)
    {
        _context = context;
    }

    public async Task<GripType> CreateGripTypeAsync(GripType gripType)
    {
        await _context.GripTypes.AddAsync(gripType);
        await _context.SaveChangesAsync();
        return gripType;
    }

    public async Task<List<GripType>> GetAllAsync()
    {
        return await _context.GripTypes.ToListAsync();
    }

    public async Task DeleteGripTypeAsync(GripType gripType)
    {
        _context.GripTypes.Remove(gripType);
        await _context.SaveChangesAsync();
    }
}

