using StoreBackend.DomainService;
using StoreBackend.Dto;
using StoreBackend.Facade.Mappers;

namespace StoreBackend.Facade;

public class UserFacade : IUserFacade
{
    private readonly IUserService userService;

    public UserFacade(IUserService userService)
    {
        this.userService = userService;
    }

    public async Task<List<UserDto>> GetAllAsync()
    {
        var users = await userService.GetAllAsync();
        return UserMapper.ToDto(users);
    }

    public async Task<UserDto?> GetByExternalIdAsync(Guid externalId)
    {
        var user = await userService.GetByExternalIdAsync(externalId);

        if (user == null)
        {
            return null;
        }

        return UserMapper.ToDto(user);
    }
}