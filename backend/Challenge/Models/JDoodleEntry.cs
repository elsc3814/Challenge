using System.Text.Json.Serialization;

namespace Challenge.Models
{
    public class JDoodleEntry
    {
        [JsonPropertyName("clientId")] public string ClientId { get; set; }
        [JsonPropertyName("clientSecret")] public string ClientSecret { get; set; }
        [JsonPropertyName("language")] public string Language { get; set; }
        [JsonPropertyName("versionIndex")] public int VersionIndex { get; set; }
        [JsonPropertyName("script")] public string Script { get; set; }
        [JsonPropertyName("stdin")] public string StdIn { get; set; }
    }
}