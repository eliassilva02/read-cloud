using Application.DTOs;
using Domain.Entities;

namespace Application.Repositories.Interfaces;

public interface IUserRepository
{
    Task<UserAuthDTO?> GetUserAsync(string userName);
    Task<int> CreateUserAsync(User user);
    Task<int> DeleteUserAsync(string userName);
    Task<int> UpdateUserAsync(string userName);
}
