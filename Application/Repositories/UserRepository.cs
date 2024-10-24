using Application.Repositories.Interfaces;
using Domain;
using Infra.Interfaces;

namespace Application.Repositories;

public class UserRepository(IRepositoryBase dataAcess) : IUserRepository
{
    private readonly IRepositoryBase _dataAcess = dataAcess;

    public async Task<UserAuth?> GetUserAsync(string userName, string password)
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

        return await _dataAcess.GetFirstAsync<UserAuth>(sql, parameters);
    }
}