using System.Text.Json.Serialization;

namespace termii.sdk.Switch.Messaging.V1.Contracts;

public class SendMessageRequest
{
    private readonly string? _sms;

    [JsonPropertyName("api_key")] public string ApiKey { get; set; } = null!;

    [JsonPropertyName("to")] public string To { get; set; } = null!;

    [JsonPropertyName("from")] public string From { get; set; } = null!;

    [JsonPropertyName("sms")]
    public string? Sms
    {
        // when media is set, sms property is set null
        get => Media == null ? _sms : null;
        init => _sms = Media == null ? value : null;
    }

    [JsonPropertyName("type")] public string Type { get; set; } = null!;

    [JsonPropertyName("channel")] public string Channel { get; set; } = null!;


    [JsonPropertyName("media")] public Media? Media { get; set; }
}

public class Media
{
    public string Url { get; set; } = null!;
    public string Caption { get; set; } = null!;
}