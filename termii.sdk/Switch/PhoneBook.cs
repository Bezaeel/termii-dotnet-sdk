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

    public async Task<CResponse> DeletePhoneBook(string phoneBookId)
    {
        string requestRoute = $"/phonebooks/{phoneBookId}/api_key={_config.APIKey}";

        var response = await _client.DeleteAsync(requestRoute);
        var r = await response.Content.ReadAsStringAsync();
        var rs = JsonSerializer.Deserialize<CResponse>(r);
        return rs;
    }

    public async Task<CResponse> UpdatePhoneBook(UpdatePhoneBookRequestDTO dto)
    {
        string requestRoute = $"/phonebooks/{dto.PhoneBookId}";
        var body = new UpdatePhoneBookRequest
        {
            APIKey = _config.APIKey,
            PhoneBookName = dto.PhoneBookName,
            Description = dto.Description
        };

        var response = await _client.PutAsJsonAsync(requestRoute, body);
        var r = await response.Content.ReadAsStringAsync();
        var rs = JsonSerializer.Deserialize<CResponse>(r);
        return rs;
    }

    public async Task<CResponse> CreatePhoneBook(CreatePhoneBookRequestDTO dto)
    {
        string requestRoute = "/phonebooks";
        var body = new CreatePhoneBookRequest
        {
            APIKey = _config.APIKey,
            PhoneBookName = dto.PhoneBookName,
            Description = dto.Description
        };

        var response = await _client.PostAsJsonAsync<CreatePhoneBookRequest>(requestRoute, body);
        var r = await response.Content.ReadAsStringAsync();
        var rs = JsonSerializer.Deserialize<CResponse>(r);
        return rs;
    }

    public async Task<FetchCResponse> GetPhoneBooks()
    {
        string apiKey = _config.APIKey;
        string requestRoute = $"/phonebooks?api_key={apiKey}";

        var response = await _client.GetAsync(requestRoute);
        var r = await response.Content.ReadAsStringAsync();
        var rs = JsonSerializer.Deserialize<FetchCResponse>(r);
        return rs;
    }
}
