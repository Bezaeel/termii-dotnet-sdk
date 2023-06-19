using Microsoft.Extensions.Options;
using System.Net.Http.Json;
using System.Text.Json;

namespace termii.sdk.Switch;
public class Messaging : IMessaging
{
    private readonly TermiiConfig _config;
    private readonly HttpClient _client = new HttpClient();
    public Messaging(IOptions<TermiiConfig> config)
    {
        _config = config.Value;
        _client.BaseAddress = new Uri(_config.BaseUrl);
    }
    public async Task<BulkMessageResponse> Bulk(BulkMessageRequestDTO dto)
    {
        string requestRoute = "/sms/send/bulk";
        var body = new BulkMessageRequest
        {
            To = dto.To,
            From = dto.From,
            Sms = dto.Sms,
            APIKey = _config.APIKey,
            Channel = dto.Channel,
            Type = dto.Type,
        };

        var response = await _client.PostAsJsonAsync<BulkMessageRequest>(requestRoute, body);
        var r = await response.Content.ReadAsStringAsync();
        var rs = JsonSerializer.Deserialize<BulkMessageResponse>(r);
        return rs;
    }
    public async Task<SendMessageResponse> Send(SendMessageRequestDTO dto)
    {
        string requestRoute = "/sms/send";
        var body = new SendMessageRequest
        {
            To = dto.To,
            From = dto.From,
            Media = dto.Media,
            Sms = dto.Sms,
            APIKey = _config.APIKey,
            Channel = dto.Channel,
            Type = dto.Type,
        };

        var response = await _client.PostAsJsonAsync<SendMessageRequest>(requestRoute, body);
        var r = await response.Content.ReadAsStringAsync();
        var rs = JsonSerializer.Deserialize<SendMessageResponse>(r);
        return rs;
    }
}
