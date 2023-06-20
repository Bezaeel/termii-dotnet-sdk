using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace termii.sdk.Switch.Campaign;

public class PhoneBook : IPhoneBook
{
    private readonly TermiiConfig _config;
    private readonly HttpClient _client = new HttpClient();
    public PhoneBook(IOptions<TermiiConfig> config)
    {
        _config = config.Value;
        _client.BaseAddress = new Uri(_config.BaseUrl);
    }

    public async Task<PhoneBookResponse> GetPhoneBooks()
    {
        string apiKey = _config.APIKey;
        string requestRoute = $"/phonebooks?api_key={apiKey}";

        var response = await _client.GetAsync(requestRoute);
        var r = await response.Content.ReadAsStringAsync();
        var rs = JsonSerializer.Deserialize<PhoneBookResponse>(r);
        return rs;
    }
}
