using Domain;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Services;

public class TokenService
{
    public static string GenerateToken(UserAuth user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes("");

        var descriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(
                [
                    new(ClaimTypes.Name, user.UserName),
                    new(ClaimTypes.Role, user.LevelUser.ToString())
                ]
            ),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
        };

        var token = tokenHandler.CreateToken(descriptor);

        return tokenHandler.WriteToken(token);
    }
}
