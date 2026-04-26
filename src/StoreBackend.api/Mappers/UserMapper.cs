using StoreBackend.Api.Models.Responses;
using StoreBackend.Dto;

namespace StoreBackend.Api.Mappers;

public static class UserMapper
{
    public static UserResponseModel ToModel(UserDto user)
    {
        return new UserResponseModel
        {
            ExternalId = user.ExternalId,
            Username = user.Username,
            Email = user.Email
        };
    }

    public static List<UserResponseModel> ToModel(List<UserDto> users)
    {
        return users.Select(ToModel).ToList();
    }
}