using Microsoft.EntityFrameworkCore;
using You.Application.Interfaces;
using You.Domain.Entities;
using You.Infrastructure.Data;

namespace You.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _db;

    public UserRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public System.Threading.Tasks.Task<User?> GetAsync(int id) => _db.Users.FirstOrDefaultAsync(u => u.Id == id);

    public async System.Threading.Tasks.Task AddAsync(User user)
    {
        _db.Users.Add(user);
        await _db.SaveChangesAsync();
    }
}
