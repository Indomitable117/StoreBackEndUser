using StoreBackend.Dto;

namespace StoreBackend.Facade;

public interface IUserFacade
{
    Task<List<UserDto>> GetAllAsync();
    Task<UserDto?> GetByExternalIdAsync(Guid externalId);
}