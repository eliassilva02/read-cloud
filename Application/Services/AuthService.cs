using Application.DTOs;
using Application.Enums;
using Application.Repositories.Interfaces;
using Application.Services.Interfaces;

namespace Application.Services;

public class AuthService(IUserRepository repo) : IAuthService
{
    private readonly IUserRepository _repo = repo;

    public async Task<AuthUserResponseDTO> LoginAsync(string userName, string password)
    {
        var user = await _repo.GetUserAsync(userName, password);

        if (user == null)
            return new("", "Usuário não encontrado", EAuthResponse.UserNotFound);

        var sucessPassword = HasherService.VerifyPasswordHash(password, user.HashPassword);

        //if (!sucessPassword)
        //    return new("", "Senha inválida", EAuthResponse.InvalidPassword);

        var token = TokenService.GenerateToken(user);
        return new(token, "Sucesso");
    }
}
