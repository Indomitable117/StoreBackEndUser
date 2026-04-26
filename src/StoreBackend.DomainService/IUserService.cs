using StoreBackend.Domain.Entities;

namespace StoreBackend.DomainService;

public interface IUserService
{
    Task<List<User>> GetAllAsync();
    Task<User?> GetByExternalIdAsync(Guid externalId);
}