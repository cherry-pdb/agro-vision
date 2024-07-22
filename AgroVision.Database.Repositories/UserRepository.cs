using AgroVision.Core.Models;
using AgroVision.Core.Repositories;
using AgroVision.Database.Context;
using AgroVision.Database.Repositories.Converters;
using Microsoft.EntityFrameworkCore;

namespace AgroVision.Database.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AgroVisionContext _dbContext;

    public UserRepository(AgroVisionContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<UserCore>> GetAllUsersAsync()
    {
        var usersDb = await _dbContext.Users
            .AsNoTracking()
            .ToListAsync();

        return usersDb.ConvertAll(UserConverter.ConvertToCore)!;
    }
    
    public async Task AddUserAsync(UserCore userCore)
    {
        var userToAdd = UserConverter.ConvertToDb(userCore)!;

        await _dbContext.Users.AddAsync(userToAdd);
        await _dbContext.SaveChangesAsync();
    }

    public async Task RemoveUserCore(Guid id)
    {
        var userToRemove = await _dbContext.Users.FindAsync(id);

        if (userToRemove is null)
            throw new InvalidOperationException($"User with id: {id} was not found.");

        _dbContext.Users.Remove(userToRemove);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<UserCore?> FindUserByIdAsync(Guid id)
    {
        var userDb = await _dbContext.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(user => user.Id == id);

        return UserConverter.ConvertToCore(userDb);
    }

    public async Task<UserCore?> FindUserByLoginAsync(string login)
    {
        var userDb = await _dbContext.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(user => user.Login == login);

        return UserConverter.ConvertToCore(userDb);
    }

    public async Task<UserCore?> FindUserByLoginCredentialsAsync(string login, string password)
    {
        var userDb = await _dbContext.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(user => user.Login == login && user.Password == password);

        return UserConverter.ConvertToCore(userDb);
    }

    public async Task UpdateUserAsync(UserCore userCore)
    {
        var userToUpdate = await _dbContext.Users.FindAsync(userCore.Id);

        if (userToUpdate is null)
            throw new InvalidOperationException($"User with id: {userCore.Id} was not found.");

        userToUpdate.Login = userCore.Login;
        userToUpdate.Password = userCore.Password;

        await _dbContext.SaveChangesAsync();
    }

    public Task<bool> ExistsUserByIdAsync(Guid id)
    {
        return _dbContext.Users.AsNoTracking().AnyAsync(user => user.Id == id);
    }

    public Task<bool> ExistsUserByLoginAsync(string login)
    {
        return _dbContext.Users.AsNoTracking().AnyAsync(user => user.Login == login);
    }
}