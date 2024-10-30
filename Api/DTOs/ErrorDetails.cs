using System.Text.Json.Serialization;

namespace read_cloud.DTOs;

public class ErrorsDetails(List<string> details, List<string>? user)
{
    [JsonPropertyName("$")]
    public List<string> Details { get; set; } = details;

    [JsonPropertyName("user")]
    public List<string>? User { get; set; } = user;
}
