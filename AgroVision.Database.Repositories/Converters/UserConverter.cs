using AgroVision.Core.Models;
using AgroVision.Database.Models;

namespace AgroVision.Database.Repositories.Converters;

public static class UserConverter
{
    public static UserCore? ConvertToCore(UserDb? userDb) 
        => userDb is null
            ? null
            : new UserCore(
                userDb.Id,
                userDb.Login,
                userDb.Password);

    public static UserDb? ConvertToDb(UserCore? userCore)
        => userCore is null 
            ? null
            : new UserDb(
                userCore.Id,
                userCore.Login,
                userCore.Password);
}