using System.Net;
using System.Net.Http.Json;
using AutoFixture;
using FluentAssertions;
using Microsoft.Extensions.Options;
using NSubstitute;
using RichardSzalay.MockHttp;
using termii.sdk.Switch.Messaging.V1.Contracts;
using termii.sdk.Switch.Messaging.V1.Services.Implementation;

namespace termii.sdk.tests.Unit.Switch.Messaging.Services;

public class MessagingApiClientTests
{
    private readonly Fixture _fixture = new();
    private readonly MockHttpMessageHandler _msgHandler = new();
    private readonly MessagingApiClient _sut;

    public MessagingApiClientTests()
    {
        var options = Substitute.For<IOptions<TermiiConfig>>();
        options.Value.Returns(new TermiiConfig
        {
            BaseUrl = "http://localhost:5000",
            APIKey = "APIKey"
        });

        var config = options.Value;
        var httpClient = new HttpClient(_msgHandler)
        {
            BaseAddress = new Uri(config.BaseUrl)
        };
        _sut = new MessagingApiClient(httpClient, options);
    }

    [Fact]
    public async Task Should()
    {
        // Arrange
        var expectedResponse = _fixture.Create<SendMessageResponse>();
        var request = _fixture.Create<SendMessageRequest>();

        _msgHandler
            .Expect(HttpMethod.Post, "/sms/send/")
            .Respond(HttpStatusCode.OK, JsonContent.Create(expectedResponse));

        // Act
        var result = await _sut.SendAsync(request, CancellationToken.None);

        // Assert
        result.Should().BeEquivalentTo(expectedResponse);
    }
}