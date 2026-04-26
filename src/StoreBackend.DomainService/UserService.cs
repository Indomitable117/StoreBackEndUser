using StoreBackend.Domain.Entities;
using StoreBackend.Infrastructure.Repositories;

namespace StoreBackend.DomainService;

public class UserService : IUserService
{
    private readonly IUserRepository userRepository;

    public UserService(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
    }

    public Task<List<User>> GetAllAsync()
    {
        return userRepository.GetAllAsync();
    }

    public Task<User?> GetByExternalIdAsync(Guid externalId)
    {
        return userRepository.GetByExternalIdAsync(externalId);
    }
}