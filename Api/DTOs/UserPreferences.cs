using System.Text.Json.Serialization;

namespace read_cloud.DTOs;
public class UserBookPreferences
{
    [JsonPropertyName("genres")]
    public List<string> Genres { get; set; }

    [JsonPropertyName("authors")]
    public List<string> Authors { get; set; }

    [JsonPropertyName("languages")]
    public List<string> Languages { get; set; }

    [JsonPropertyName("book_series")]
    public List<Guid> BookSeriesGuid { get; set; }

    [JsonPropertyName("books")]
    public List<Guid> BooksGuid { get; set; }
}