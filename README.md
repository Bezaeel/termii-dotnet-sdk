# termii-dotnet-sdk

A .NET 8 SDK for the [Termii API](https://developer.termii.com/), providing a strongly-typed, DI-friendly client for sending SMS messages and more.

## Requirements

- .NET 8.0+

## Installation

> NuGet package coming soon. In the meantime, reference the project directly.

```xml
<ProjectReference Include="../termii.sdk/termii.sdk.csproj" />
```

## Configuration

Add a `Termii` section to your `appsettings.json`:

```json
{
  "Termii": {
    "BaseUrl": "https://api.termii.com/",
    "APIKey": "your-api-key-here"
  }
}
```

## Setup

Register the SDK in your `Program.cs` or `Startup.cs`:

```csharp
builder.Services.AddTermiiApiClient(builder.Configuration);
```

You can optionally customise the underlying `HttpClient`:

```csharp
builder.Services.AddTermiiApiClient(builder.Configuration, httpClientBuilder =>
{
    httpClientBuilder.ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
    {
        // custom handler options
    });
});
```

The SDK automatically registers a retry policy (3 attempts, 2-second delay) using `Microsoft.Extensions.Http.Resilience`.

## Usage

### Send a message

Inject `IMessagingApiClient` into your service or controller:

```csharp
using termii.sdk.Switch.Messaging.V1.Services;
using termii.sdk.Switch.Messaging.V1.Contracts;

public class NotificationService(IMessagingApiClient messaging)
{
    public async Task SendOtpAsync(string phoneNumber, string otp, CancellationToken ct = default)
    {
        var response = await messaging.SendAsync(new SendMessageRequest
        {
            To      = phoneNumber,   // e.g. "2348012345678"
            From    = "YourBrand",   // sender ID registered on Termii
            Sms     = $"Your OTP is {otp}",
            Type    = "plain",
            Channel = "generic"
        }, ct);

        Console.WriteLine($"MessageId: {response.MessageId}, Balance: {response.Balance}");
    }
}
```

### Send a message with media

```csharp
var response = await messaging.SendAsync(new SendMessageRequest
{
    To      = "2348012345678",
    From    = "YourBrand",
    Type    = "plain",
    Channel = "whatsapp",
    Media   = new Media
    {
        Url     = "https://example.com/image.png",
        Caption = "Check this out!"
    }
}, cancellationToken);
```

> When `Media` is set, the `Sms` property is automatically ignored per the Termii API specification.

## API Reference

### `IMessagingApiClient`

| Method | Description |
|---|---|
| `SendAsync(SendMessageRequest, CancellationToken)` | Send a single SMS or media message |

### `SendMessageRequest`

| Property | JSON key | Required | Description |
|---|---|---|---|
| `To` | `to` | Yes | Recipient phone number in international format |
| `From` | `from` | Yes | Sender ID or name registered on Termii |
| `Sms` | `sms` | Yes* | Message body. Ignored when `Media` is set |
| `Type` | `type` | Yes | Message type (e.g. `plain`) |
| `Channel` | `channel` | Yes | Channel to use (e.g. `generic`, `whatsapp`) |
| `Media` | `media` | No | Media object for rich-media messages |

### `SendMessageResponse`

| Property | JSON key | Description |
|---|---|---|
| `MessageId` | `message_id` | Unique ID assigned to the message |
| `Message` | `message` | Human-readable status from Termii |
| `Balance` | `balance` | Remaining account balance after sending |
| `User` | `user` | Account identifier |

## Feature Coverage

### Switch

| Feature | Endpoint | Status |
|---|---|---|
| Send message | `POST /api/sms/send` | ✅ Implemented |

## Project Structure

```
termii-dotnet-sdk/
├── termii.sdk/
│   ├── Common/Http/          # Resilience / retry configuration
│   ├── Switch/Messaging/     # Messaging feature
│   │   └── V1/
│   │       ├── Contracts/    # Request & response models
│   │       └── Services/     # IMessagingApiClient + implementation
│   ├── DependencyInjection.cs
│   └── TermiiConfig.cs
└── termii.sdk.tests/
    └── Unit/Switch/Messaging/
```

## Running Tests

```bash
dotnet test
```

## License

MIT
