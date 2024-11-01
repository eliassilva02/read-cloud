using System.Text.Json.Serialization;

namespace read_cloud.DTOs;

public class ErrorResponse
{
    public ErrorResponse()
    {
    }

    public ErrorResponse(string title, int status, ErrorsDetails errors)
    {
        Type = "https://datatracker.ietf.org/doc/html/rfc9110#section-15";
        Title = title;
        Status = status;
        Errors = errors;
    }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("status")]
    public int Status { get; set; }

    [JsonPropertyName("errors")]
    public ErrorsDetails Errors { get; set; }
}