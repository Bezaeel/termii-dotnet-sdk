using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace termii.sdk.Switch;

public class Number : INumber
{
    private readonly TermiiConfig _config;
    private readonly HttpClient _client = new HttpClient();
    public Number(IOptions<TermiiConfig> config)
    {
        _config = config.Value;
        _client.BaseAddress = new Uri(_config.BaseUrl);
    }

    public async Task<NumberMessageResponse> Send(NumberMessageRequestDTO dto)
    {
        string requestRoute = "/sms/number/send";
        var body = new NumberMessageRequest
        {
            To = dto.To,
            Sms = dto.Sms,
            APIKey = _config.APIKey,
        };

        var response = await _client.PostAsJsonAsync<NumberMessageRequest>(requestRoute, body);
        var r = await response.Content.ReadAsStringAsync();
        var rs = JsonSerializer.Deserialize<NumberMessageResponse>(r);
        return rs;
    }
}