using System.Text.Json.Serialization;

namespace Challenge.Models
{
    public class JDoodleResponse
    {
        [JsonPropertyName("output")] public string Output { get; set; }
        [JsonPropertyName("memory")] public string Memory { get; set; }
        [JsonPropertyName("cpuTime")] public string CpuTime { get; set; }
    }
}