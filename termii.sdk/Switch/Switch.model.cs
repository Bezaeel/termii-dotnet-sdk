using System.Text.Json.Serialization;

namespace termii.sdk.Switch;

public class GetSenderIdResponseData
{
    [JsonPropertyName("sender_id")]
    public string SenderId { get; set; }

    [JsonPropertyName("usecase")]
    public string Usecase { get; set; }

    [JsonPropertyName("company")]
    public string Company { get; set; }

    [JsonPropertyName("country")]
    public string Country { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set;}

    [JsonPropertyName("created_at")]
    public string CreatedAt { get; set; }
}

public class GetSenderIdResponse
{
    [JsonPropertyName("current_page")]
    public int CurrentPage { get; set; }

    [JsonPropertyName("data")]
    public GetSenderIdResponseData Data { get; set; }

    [JsonPropertyName("from")]
    public int From { get; set; }

    [JsonPropertyName("total")]
    public int Total { get; set; }

    [JsonPropertyName("to")]
    public int To { get; set; }

    [JsonPropertyName("first_page_url")]
    public string FirstPageUrl { get; set; }

    [JsonPropertyName("last_page")]
    public int LastPage { get; set; }

    [JsonPropertyName("last_page_url")]
    public string LastPageUrl { get; set; }

    [JsonPropertyName("next_page_url")]
    public string NextPageUrl { get; set; }

    [JsonPropertyName("pre_page_url")]
    public string PrevPageUrl { get; set; }

    [JsonPropertyName("path")]
    public string Path { get; set; }

    [JsonPropertyName("per_page")]
    public int PerPage { get; set; }
}

public class RegisterSenderIdResponse
{
    [JsonPropertyName("code")]
    public string Code { get; set; }

    [JsonPropertyName("message")]
    public string Message { get; set; }
}

public class RegisterSenderIdRequestDTO
{
    public string SenderId { get; set; }
    public string Usecase { get; set; }
    public string Company { get; set; }
}


public class RegisterSenderIdRequest
{
    [JsonPropertyName("sender_id")]
    public string SenderId { get; set; }

    [JsonPropertyName("usecase")]
    public string Usecase { get; set; }

    [JsonPropertyName("company")]
    public string Company { get; set; }

    [JsonPropertyName("api_key")]
    public string APIKey { get; set; }
}

public class SendMessageRequestDTO
{
    public string To { get; set; }
    public string From { get; set; }
    public string Sms { get; set; }
    public string Type { get; set; }
    public string Channel { get; set; }
    public Media Media { get; set; }

}

public class SendMessageRequest
{
    [JsonPropertyName("to")]
    public string To { get; set; }

    [JsonPropertyName("from")]
    public string From { get; set; }

    [JsonPropertyName("sms")]
    public string Sms { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("channel")]
    public string Channel { get; set; }

    [JsonPropertyName("api_key")]
    public string APIKey { get; set; }

    [JsonPropertyName("media")]
    public Media Media { get; set; }

}

public class SendMessageResponse
{
    [JsonPropertyName("message_id")]
    public string MessageID { get; set; }

    [JsonPropertyName("message")]
    public string Message { get; set; }

    [JsonPropertyName("balance")]
    public int Balance { get; set; }

    [JsonPropertyName("user")]
    public string User { get; set; }
}
