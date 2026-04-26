using StoreBackend.Domain.Entities;
using StoreBackend.Dto;

namespace StoreBackend.Facade.Mappers;

public static class UserMapper
{
    public static UserDto ToDto(User user)
    {
        return new UserDto
        {
            ExternalId = user.ExternalId,
            Username = user.Username,
            Email = user.Email,
            PasswordHash = user.PasswordHash
        };
    }

    public static List<UserDto> ToDto(List<User> users)
    {
        return users.Select(ToDto).ToList();
    }
}