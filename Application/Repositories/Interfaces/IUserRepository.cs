using Domain;

namespace Application.Repositories.Interfaces;

public interface IUserRepository
{
    Task<UserAuth?> GetUserAsync(string userName, string password);
}
