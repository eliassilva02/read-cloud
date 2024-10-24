using System.Text.Json.Serialization;

namespace read_cloud.DTOs;

public class ErrorDetails
{
    [JsonPropertyName("field")]
    public string Field { get; set; }

    [JsonPropertyName("error")]
    public string Error { get; set; }
}
