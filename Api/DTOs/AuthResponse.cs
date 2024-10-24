using System.Text.Json.Serialization;

namespace read_cloud.DTOs;

public class AuthResponse(string message, string token)
{
    [JsonPropertyName("message")]
    public string Message { get; set; } = message;

    [JsonPropertyName("token")]
    public string Token { get; set; } = token;
}
