using Microsoft.Extensions.DependencyInjection;
using termii.sdk.Common.Http;
using termii.sdk.Switch.Messaging.V1.Services;
using termii.sdk.Switch.Messaging.V1.Services.Implementation;

namespace termii.sdk.Switch.Messaging;

public static class DependencyInjection
{
    public static IServiceCollection AddMessaging(this IServiceCollection services,
        TermiiConfig termiiConfig,
        Action<IHttpClientBuilder>? configureHttpClient = null)
    {
        services
            .AddHttpClient<IMessagingApiClient, MessagingApiClient>(typeof(MessagingApiClient).FullName!,
                (_, client) => { client.BaseAddress = new Uri(termiiConfig.BaseUrl); })
            .ConfigureHttpClient(configureHttpClient);

        return services;
    }
}