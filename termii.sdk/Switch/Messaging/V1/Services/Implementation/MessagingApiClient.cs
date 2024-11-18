using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.Extensions.Options;
using termii.sdk.Switch.Messaging.V1.Contracts;

namespace termii.sdk.Switch.Messaging.V1.Services.Implementation;

public class MessagingApiClient(HttpClient httpClient, IOptions<TermiiConfig> config) : IMessagingApiClient
{
    private readonly TermiiConfig _config = config.Value;

    public async Task<SendMessageResponse> SendAsync(SendMessageRequest dto,
        CancellationToken cancellationToken = default)
    {
        var body = new SendMessageRequest
        {
            To = dto.To,
            From = dto.From,
            Media = dto.Media,
            Sms = dto.Sms,
            ApiKey = _config.APIKey,
            Channel = dto.Channel,
            Type = dto.Type
        };

        var response = await httpClient.PostAsJsonAsync("/sms/send/", body, cancellationToken);
        var responseContent = await response.Content.ReadAsStreamAsync(cancellationToken);
        var result = JsonSerializer.Deserialize<SendMessageResponse>(responseContent);
        return result!;
    }
}