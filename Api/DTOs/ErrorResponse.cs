using System.Text.Json;
using System.Text.Json.Serialization;
using read_cloud.Extensions;

namespace read_cloud.DTOs;

public class ErrorResponse(string message, List<ErrorDetails>? details)
{

    [JsonPropertyName("date")]
    public DateTime DateError = DateTime.UtcNow.OnBrazil();

    [JsonPropertyName("message")]
    public string Message { get; private set; } = message;

    [JsonPropertyName("message")]
    public List<ErrorDetails>? Details { get; private set; } = details;
}
