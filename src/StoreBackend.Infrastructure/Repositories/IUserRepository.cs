using StoreBackend.Domain.Entities;

namespace StoreBackend.Infrastructure.Repositories;

public interface IUserRepository
{
    Task<List<User>> GetAllAsync();
    Task<User?> GetByExternalIdAsync(Guid externalId);
}