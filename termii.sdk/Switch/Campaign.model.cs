using Microsoft.AspNetcore.Http;
using System.Text.Json.Serialization;

namespace termii.sdk.Switch.Campaign;

public class BulkCreateContactRequestDTO
{
    [JsonPropertyName("contact_file")]
    public IFormFile ContactFile { get; set; }

    [JsonPropertyName("country_code")]
    public string CountryCode { get; set; }
}

public class BulkCreateContactRequest
{
    [JsonPropertyName("api_key")]
    public string APIKey { get; set; }

    [JsonPropertyName("contact_file")]
    public IFormFile ContactFile { get; set; }

    [JsonPropertyName("country_code")]
    public string CountryCode { get; set; }
}

public class CreateContactResponse
{
    [JsonPropertyName("data")]
    public CreateContactResponseData Data { get; set; }
}

public class CreateContactResponseData
{
    [JsonPropertyName("phone_number")]
    public string? PhoneNumber { get; set; }

    [JsonPropertyName("email_address")]
    public string? EmailAddress { get; set; }

    [JsonPropertyName("message")]
    public string? Message { get; set; }

    [JsonPropertyName("company")]
    public string? Company { get; set; }

    [JsonPropertyName("first_name")]
    public string? FirstName { get; set; }

    [JsonPropertyName("last_name")]
    public string? LastName { get; set; }

    [JsonPropertyName("create_at")]
    public string? CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public string? UpdatedAt { get; set; }
}

public class CreateContactRequestDTO
{
    [JsonPropertyName("phone_number")]
    public string PhoneNumber { get; set; }

    [JsonPropertyName("country_code")]
    public string? CountryCode { get; set; }

    [JsonPropertyName("email_address")]
    public string? EmailAddress { get; set; }

    [JsonPropertyName("company")]
    public string? Company { get; set; }

    [JsonPropertyName("first_name")]
    public string? FirstName { get; set; }

    [JsonPropertyName("last_name")]
    public string? LastName { get; set; }
}

public class CreateContactRequest
{
    [JsonPropertyName("api_key")]
    public string APIKey { get; set; }

    [JsonPropertyName("phone_number")]
    public string PhoneNumber { get; set; }

    [JsonPropertyName("country_code")]
    public string? CountryCode { get; set; }

    [JsonPropertyName("email_address")]
    public string? EmailAddress { get; set; }

    [JsonPropertyName("company")]
    public string? Company { get; set; }

    [JsonPropertyName("first_name")]
    public string? FirstName { get; set; }

    [JsonPropertyName("last_name")]
    public string? LastName { get; set; }
}

public class FetchContactsResponse
{
    [JsonPropertyName("data")]
    public List<FetchContactsResponseData> Data { get; set; }

    [JsonPropertyName("links")]
    public Link links { get; set; }

    [JsonPropertyName("meta")]
    public Meta meta { get; set; }
}

public class FetchContactsResponseData
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("pid")]
    public int PID { get; set; }

    [JsonPropertyName("phone_number")]
    public string? PhoneNumber { get; set; }

    [JsonPropertyName("email_address")]
    public string? EmailAddress { get; set; }

    [JsonPropertyName("message")]
    public string? Message { get; set; }

    [JsonPropertyName("company")]
    public string? Company { get; set; }

    [JsonPropertyName("first_name")]
    public string? FirstName { get; set; }

    [JsonPropertyName("last_name")]
    public string? LastName { get; set; }

    [JsonPropertyName("create_at")]
    public string? CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public string? UpdatedAt { get; set; }

}

public class UpdatePhoneBookRequestDTO
{
    [JsonPropertyName("phonebook_id")]
    public string PhoneBookId { get; set; }

    [JsonPropertyName("phonebook_name")]
    public string PhoneBookName { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }
}

public class UpdatePhoneBookRequest
{
    [JsonPropertyName("api_key")]
    public string APIKey { get; set; }

    [JsonPropertyName("phonebook_name")]
    public string PhoneBookName { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }
}

public class CreatePhoneBookRequestDTO
{
    [JsonPropertyName("phonebook_name")]
    public string PhoneBookName { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }
}

public class CreatePhoneBookRequest
{
    [JsonPropertyName("api_key")]
    public string APIKey { get; set; }

    [JsonPropertyName("phonebook_name")]
    public string PhoneBookName { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }
}

public class CResponse
{
    [JsonPropertyName("message")]
    public string Message { get; set; }
}

public class FetchPhoneBookResponse
{
    [JsonPropertyName("data")]
    public List<FetchPhoneBookResponseData> Data { get; set; }

    [JsonPropertyName("links")]
    public Link links { get; set; }

    [JsonPropertyName("meta")]
    public Meta meta { get; set; }
}

public class FetchPhoneBookResponseData
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("taoal_number_of_contacts")]
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
