using termii.sdk.Switch.Messaging.V1.Contracts;

namespace termii.sdk.Switch.Messaging.V1.Services;

public interface IMessagingApiClient
{
    Task<SendMessageResponse> SendAsync(SendMessageRequest dto, CancellationToken cancellationToken);
}