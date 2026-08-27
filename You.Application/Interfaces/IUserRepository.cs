using You.Domain.Entities;

namespace You.Application.Interfaces;

public interface IUserRepository
{
    System.Threading.Tasks.Task<User?> GetAsync(int id);
    System.Threading.Tasks.Task AddAsync(User user);
}
