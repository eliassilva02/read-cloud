using System.Text.Json.Serialization;

namespace read_cloud.DTOs;

public class LoginDTO
{
    [JsonPropertyName("username")]
    public string UserName { get; set; }

    [JsonPropertyName("password")]
    public string Password { get; set; }
}
