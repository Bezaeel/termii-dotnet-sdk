using System.Text.Json.Serialization;

namespace termii.sdk.Switch.Messaging.V1.Contracts;

public class SendMessageResponse
{
    [JsonPropertyName("message_id")] public string MessageId { get; set; } = null!;

    [JsonPropertyName("message")] public string Message { get; set; } = null!;

    [JsonPropertyName("balance")] public int Balance { get; set; }

    [JsonPropertyName("user")] public string User { get; set; } = null!;
}