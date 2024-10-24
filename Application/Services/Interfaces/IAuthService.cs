using Application.DTOs;

namespace Application.Services.Interfaces;

public interface IAuthService
{
    Task<AuthUserResponseDTO> LoginAsync(string userName, string password);
}
