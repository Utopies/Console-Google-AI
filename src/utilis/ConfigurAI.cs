using System.Text.Json;

public static class ConfigurAI
{
    /// <summary>
    /// Асинхронно читает конфигурацию из AIConf.json.
    /// </summary>
    public static async Task<AiConfig> LoadAiConfigAsync(string path = "AIConf.json", CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(path)) throw new ArgumentException(nameof(path));
        if (!File.Exists(path)) throw new FileNotFoundException($"Configuration file not found: {path}", path);

        var json = await File.ReadAllTextAsync(path, cancellationToken).ConfigureAwait(false);

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        var cfg = JsonSerializer.Deserialize<AiConfig?>(json, options)
            ?? throw new InvalidOperationException("Unable to deserialize AI configuration.");

        return cfg;
    }

    /// <summary>
    /// Синхронный вариант чтения конфигурации.
    /// </summary>
    public static AiConfig LoadAiConfig(string path = "AIConf.json")
    {
        if (string.IsNullOrWhiteSpace(path)) throw new ArgumentException(nameof(path));
        if (!File.Exists(path)) throw new FileNotFoundException($"Configuration file not found: {path}", path);

        var json = File.ReadAllText(path);

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        return JsonSerializer.Deserialize<AiConfig?>(json, options)
            ?? throw new InvalidOperationException("Unable to deserialize AI configuration.");
    }
}
