using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using termii.sdk.Switch.Messaging;

namespace termii.sdk;

public static class DependencyInjection
{
    public static IServiceCollection AddTermiiApiClient(this IServiceCollection services,
        IConfiguration configuration,
        Action<IHttpClientBuilder>? configureHttpClient = null)
    {
        var termiiConfig = configuration.GetSection("Termii").Get<TermiiConfig>()
                           ?? throw new InvalidOperationException(
                               "Termii configuration is missing. Please add 'Termii' section to the appsettings.json file.");
        return services
            .AddMessaging(termiiConfig, configureHttpClient);
    }
}