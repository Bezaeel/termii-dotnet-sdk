using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace termii.sdk.Switch.Campaign;

public class PhoneBookResponse
{
    [JsonPropertyName("data")]
    public List<PhoneBookResponseData> Data { get; set; }

    [JsonPropertyName("links")]
    public Link links { get; set; }

    [JsonPropertyName("meta")]
    public Meta meta { get; set; }
}

public class PhoneBookResponseData
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("first")]
    public string TotalNumberOfContacts { get; set; }

    [JsonPropertyName("date_created")]
    public string DateCreated { get; set; }

    [JsonPropertyName("last_updated")]
    public string LastUpdated { get; set; }
}

public class Link
{
    [JsonPropertyName("first")]
    public string First { get; set; }

    [JsonPropertyName("last")]
    public string Last { get; set; }

    [JsonPropertyName("prev")]
    public dynamic Prev { get; set; }

    [JsonPropertyName("next")]
    public dynamic Next { get; set; }
}

public class Meta
{
    [JsonPropertyName("current_page")]
    public int CurrentPage { get; set; }

    [JsonPropertyName("from")]
    public string From { get; set; }

    [JsonPropertyName("last_page")]
    public int LastPage { get; set; }

    [JsonPropertyName("path")]
    public string Path { get; set; }

    [JsonPropertyName("per_page")]
    public int PerPage { get; set; }

    [JsonPropertyName("to")]
    public int To { get; set; }

    [JsonPropertyName("total")]
    public int Total { get; set; }
}
