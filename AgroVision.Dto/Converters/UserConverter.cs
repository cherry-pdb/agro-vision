using AgroVision.Core.Models;
using AgroVision.Dto.Models;

namespace AgroVision.Dto.Converters;

public static class UserConverter
{
    public static UserCore? ConvertToCore(UserDto? userDto) 
        => userDto is null
            ? null
            : new UserCore(
                userDto.Id,
                userDto.Login,
                userDto.Password);

    public static UserDto? ConvertToDto(UserCore? userCore)
        => userCore is null 
            ? null
            : new UserDto(
                userCore.Id,
                userCore.Login,
                userCore.Password);
}