using Application.DTOs;
using Application.Repositories.Interfaces;
using Infra.Interfaces;
using Domain.Entities;

namespace Application.Repositories;

public class UserRepository(IRepositoryBase dataAcess) : IUserRepository
{
    private readonly IRepositoryBase _dataAcess = dataAcess;

    public Task<int> CreateUserAsync(User user)
    {
        var sql = $@"
            INSERT INTO 
        ";

        var parameters = new
        {
            _userName = userName
        };

        return _dataAcess.ExecuteAsync(sql, parameters);
    }

    public Task<int> DeleteUserAsync(string userName)
    {
        throw new NotImplementedException();
    }

    public async Task<UserAuthDTO?> GetUserAsync(string userName)
    {
        var sql = $@"
            SELECT
                user_name ""UserName"",
                user_password ""HashPassword"",
                user_type ""LevelUser""
            FROM users
            WHERE user_name = @_userName
                OR user_email = @_userName
        ";

        var parameters = new
        {
            _userName = userName
        };

        return await _dataAcess.GetFirstAsync<UserAuthDTO>(sql, parameters);
    }

    public Task<int> UpdateUserAsync(string userName)
    {
        throw new NotImplementedException();
    }
}