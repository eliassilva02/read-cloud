using System.Text.Json.Serialization;

namespace read_cloud.DTOs;

public class UserRequestDTO
{
    [JsonPropertyName("name"), JsonRequired]
    public string Name { get; set; }

    [JsonPropertyName("username")]
    public string UserName { get; set; }

    [JsonPropertyName("email"), JsonRequired]
    public string Email { get; set; }

    [JsonPropertyName("password"), JsonRequired]
    public string Password { get; set; }

    [JsonPropertyName("cpf"), JsonRequired]
    public string Cpf { get; set; }

    [JsonPropertyName("dateBirth")]
    public DateTime DateBirth { get; set; }

    [JsonPropertyName("phone")]
    public string Phone { get; set; }

    [JsonPropertyName("address")]
    public AddressRequestDTO Address { get; set; }

    [JsonPropertyName("levelUser")]
    public int LevelUser { get; set; }
}
