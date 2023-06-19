using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace termii.sdk.Switch;

public class Template : ITemplate
{
    private readonly TermiiConfig _config;
    private readonly HttpClient _client = new HttpClient();
    public Template(IOptions<TermiiConfig> config)
    {
        _config = config.Value;
        _client.BaseAddress = new Uri(_config.BaseUrl);
    }

    public async Task<TemplateResponse> Send(TemplateRequestDTO dto)
    {
        string requestRoute = "/templat/send";
        var body = new TemplateRequest
        {
            Phone = dto.Phone,
            DeviceId  = dto.DeviceId,
            TemplateId = dto.TemplateId,
            APIKey = _config.APIKey,
            Data = dto.Data,
        };

        var response = await _client.PostAsJsonAsync<TemplateRequest>(requestRoute, body);
        var r = await response.Content.ReadAsStringAsync();
        var rs = JsonSerializer.Deserialize<TemplateResponse>(r);
        return rs;
    }
}
