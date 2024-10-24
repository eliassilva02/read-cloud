using System.Text.Json.Serialization;

namespace read_cloud.DTOs;

public class UserRequest
{
    [JsonIgnore]
    public Guid Id { get; set; } = Guid.NewGuid();

    [JsonPropertyName("name"), JsonRequired]
    public string Name { get; set; }

    [JsonPropertyName("username"), JsonRequired]
    public string UserName { get; set; }

    [JsonPropertyName("email"), JsonRequired]
    public string Email { get; set; }

    [JsonPropertyName("password"), JsonRequired]
    public string Password { get; set; }

    [JsonPropertyName("date_birth"), JsonRequired]
    public DateTime DateBirth { get; set; }

    [JsonPropertyName("phone"), JsonRequired]
    public string Phone { get; set; }
}