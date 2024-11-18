using System.Text.Json.Serialization;

namespace termii.sdk.Switch.Messaging.V1.Contracts;

public class SendBulkMessageRequest
{
    [JsonPropertyName("api_key")] public string APIKey { get; set; }

    [JsonPropertyName("to")] public string To { get; set; }

    [JsonPropertyName("from")] public string From { get; set; }

    [JsonPropertyName("sms")] public string Sms { get; set; }

    [JsonPropertyName("type")] public string Type { get; set; }

    [JsonPropertyName("channel")] public string Channel { get; set; }
}