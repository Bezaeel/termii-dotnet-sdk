using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http.Resilience;
using Polly;

namespace termii.sdk.Common.Http;

internal static class HttpConfiguration
{
    private const int RetryCount = 3;

    public static IHttpClientBuilder ConfigureHttpClient(this IHttpClientBuilder httpClientBuilder,
        Action<IHttpClientBuilder>? configureHttpClient = null,
        bool enableRequestLogging = false)
    {
        httpClientBuilder.AddResilienceHandler("", builder =>
        {
            builder.AddRetry(new HttpRetryStrategyOptions
            {
                Delay = TimeSpan.FromSeconds(2),
                MaxRetryAttempts = RetryCount,
                ShouldHandle = new PredicateBuilder<HttpResponseMessage>()
                    .Handle<Exception>()
                    .HandleResult(response => !response.IsSuccessStatusCode)
            });
        });
        configureHttpClient?.Invoke(httpClientBuilder);

        return httpClientBuilder;
    }
}