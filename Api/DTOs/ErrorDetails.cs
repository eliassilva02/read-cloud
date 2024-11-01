using System.Text.Json.Serialization;

namespace read_cloud.DTOs;

public class ErrorsDetails(List<string> messages, List<string>? keys)
{
    [JsonPropertyName("$")]
    public List<string> Messages { get; set; } = messages;

    [JsonPropertyName("user")]
    public List<string>? Keys { get; set; } = keys;
}
