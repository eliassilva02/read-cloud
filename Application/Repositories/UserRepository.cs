using Application.DTOs;
using Application.Repositories.Interfaces;
using Infra.Interfaces;
using Domain.Entities;

namespace Application.Repositories;

public class UserRepository(IRepositoryBase dataAcess) : IUserRepository
{
    private readonly IRepositoryBase _dataAcess = dataAcess;

    public async Task<int> CreateUserAsync(User? user)
    {
        if (user == null) 
            return 0;

        var sql = $@"
            INSERT INTO users (user_id, user_name, user_username, user_email, user_phone, user_cpf, user_password, user_date_of_birth, user_level_user)
            VALUES (@id, @name, @username, @email, @phone, @cpf, @password, @dateOfBirth, @levelUser);
        ";

        var parameters = new
        {
            id = user.Id,
            name = user.Name,
            username = user.UserName,
            email = user.Email,
            phone = user.Phone,
            cpf = user.Cpf,
            password = user.Password,
            dateOfBirth = user.DateOfBirth,
            levelUser = (int)user.LevelUser
        };

        return await _dataAcess.ExecuteAsync(sql, parameters);
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