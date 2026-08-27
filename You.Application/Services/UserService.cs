using You.Application.Interfaces;
using You.Domain.Entities;

namespace You.Application.Services;

public class UserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }

    public System.Threading.Tasks.Task<User?> GetUserAsync(int id) => _repository.GetAsync(id);
    public System.Threading.Tasks.Task AddUserAsync(User user) => _repository.AddAsync(user);
}
