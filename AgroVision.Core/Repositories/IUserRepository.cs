using AgroVision.Core.Models;

namespace AgroVision.Core.Repositories;

public interface IUserRepository
{
    Task<List<UserCore>> GetAllUsersAsync();
    
    Task AddUserAsync(UserCore userCore);

    Task RemoveUserCore(Guid id);

    Task<UserCore?> FindUserByIdAsync(Guid id);

    Task<UserCore?> FindUserByLoginAsync(string login);

    Task<UserCore?> FindUserByLoginCredentialsAsync(string login, string password);

    Task UpdateUserAsync(UserCore userCore);

    Task<bool> ExistsUserByIdAsync(Guid id);

    Task<bool> ExistsUserByLoginAsync(string login);
}