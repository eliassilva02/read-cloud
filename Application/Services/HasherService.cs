using System.Security.Cryptography;
using System.Text;

namespace Application.Services;

public class HasherService
{
    public static string ComputeHash(string password)
    {
        var bytePassword = Encoding.UTF8.GetBytes(password);
        var byteHash = SHA256.HashData(bytePassword);
        var hash = Convert.ToHexString(byteHash);

        return hash;
    }

    public static bool VerifyPasswordHash(string password, string hashPassword) =>
        ComputeHash(password) == hashPassword;
}
