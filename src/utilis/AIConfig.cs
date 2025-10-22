using System.Text.Json.Serialization;

public struct AiConfig
{
    [JsonPropertyName("apiKey")]
    public string ApiKey { get; set; }
}