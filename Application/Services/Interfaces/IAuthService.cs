using Application.DTOs;

namespace Application.Services.Interfaces;

public interface IAuthService
{
    Task<AuthUserDTO> LoginAsync(string userName, string password);
}
