using Application.Enums;

namespace Application.DTOs;

public class AuthUserResponseDTO(string token, string message, EAuthResponse result = EAuthResponse.Success)
{
    public EAuthResponse Result { get; set; } = result;
    public string Message { get; set; } = message;
    public string Token { get; set; } = token;
}
