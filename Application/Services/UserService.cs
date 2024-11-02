using Application.DTOs;
using Application.Repositories.Interfaces;
using Domain.Entities;
using Flunt.Notifications;

namespace Application.Services;

public class UserService(IUserRepository repo)
{
    private readonly IUserRepository _repo = repo;

    public async Task<List<Notification>> CreateUserAsync(UserDTO user)
    {
        var address = user.Address;

        User userEntity = new(user.Name, user.UserName, user.Email, user.Phone, new(address.Cep, address.Street, address.Number, address.City, address.ReferencePoint, address.Complement, address.Country), user.Cpf, user.Password, user.DateBirth, user.LevelUser);
        userEntity.Validation();

        if (!userEntity.IsValid)
            return [.. userEntity.Notifications];

        var hashPassword = HasherService.ComputeHash(userEntity.Password);
        userEntity.SetPassword(hashPassword);

        await _repo.CreateUserAsync(userEntity);

        return [];
    }
}
