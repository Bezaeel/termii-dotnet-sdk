using Microsoft.Extensions.Options;
using System.Net.Http.Json;
using System.Text.Json;

namespace termii.sdk.Switch;

public class Sender : ISender
{
    private readonly TermiiConfig _config;
    private readonly HttpClient _client = new HttpClient();
    public Sender(IOptions<TermiiConfig> config)
    {
        _config = config.Value;
        _client.BaseAddress = new Uri(_config.BaseUrl);
    }
    public async Task<GetSenderIdResponse> GetSenderId()
    {
        string apiKey = _config.APIKey;
        string requestRoute = $"/sender-id?api_key={apiKey}";

        var response = await _client.GetAsync(requestRoute);
        var r = await response.Content.ReadAsStringAsync();
        var rs = JsonSerializer.Deserialize<GetSenderIdResponse>(r);
        return rs;
    }

    public async Task<RegisterSenderIdResponse> RegisterSenderId(RegisterSenderIdRequestDTO dto)
    {
        string requestRoute = "/sender-id/request";
        var qParams = new RegisterSenderIdRequest
        {
            APIKey = _config.APIKey,
            SenderId = dto.SenderId,
            Company = dto.Company,
            Usecase = dto.Usecase,
        };

        var response = await _client.PostAsJsonAsync<RegisterSenderIdRequest>(requestRoute, qParams);
        var r = await response.Content.ReadAsStringAsync();
        var rs = JsonSerializer.Deserialize<RegisterSenderIdResponse>(r);
        return rs;
    }
}
