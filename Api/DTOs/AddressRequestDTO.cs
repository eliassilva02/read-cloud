using System.Text.Json.Serialization;

namespace read_cloud.DTOs;

public class AddressRequestDTO
{
    [JsonPropertyName("cep"), JsonRequired]
    public string Cep { get; set; }

    [JsonPropertyName("street"), JsonRequired]
    public string Street { get; set; }

    [JsonPropertyName("number"), JsonRequired]
    public int Number { get; set; }

    [JsonPropertyName("state"), JsonRequired]
    public string State { get; set; }

    [JsonPropertyName("city"), JsonRequired]
    public string City { get; set; }

    [JsonPropertyName("country"), JsonRequired]
    public string Country { get; set; }

    [JsonPropertyName("complement")]
    public string? Complement { get; set; }
    
    [JsonPropertyName("referencePoint")]
    public string? ReferencePoint { get; set; }
}