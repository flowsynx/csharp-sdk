using FlowSynx.Client.Exceptions;
using FlowSynx.Client.Http;
using FlowSynx.Client.Requests;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace FlowSynx.Client.UnitTests.Http;

public class HttpRequestServiceTests
{
    private const string BaseAddress = "https://tests.flowsynx.io";

    private HttpRequestService CreateService(HttpMessageHandler handler)
    {
        var client = new HttpClient(handler) { BaseAddress = new Uri(BaseAddress) };
        var service = (HttpRequestService)Activator.CreateInstance(typeof(HttpRequestService),
            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance,
            null, new object[] { BaseAddress }, null)!;

        // Inject our mocked HttpClient
        typeof(HttpRequestService)
            .GetField("_httpClient", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)!
            .SetValue(service, client);

        return service;
    }

    [Fact]
    public void UseBasicAuth_SetsAuthorizationHeader()
    {
        var service = HttpRequestService.Create(BaseAddress);
        var username = "user";
        var password = "pass";

        service.UseBasicAuth(username, password);

        var expected = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{username}:{password}"));
        Assert.Equal($"Basic {expected}", service.AuthorizationHeader()?.ToString());
    }

    [Fact]
    public void UseBearerToken_SetsAuthorizationHeader()
    {
        var service = HttpRequestService.Create(BaseAddress);
        var token = "sample_token";

        service.UseBearerToken(token);

        Assert.Equal($"Bearer {token}", service.AuthorizationHeader()?.ToString());
    }

    [Fact]
    public void ClearAuthentication_RemovesAuthorizationHeader()
    {
        var service = HttpRequestService.Create(BaseAddress);
        service.UseBearerToken("anytoken");

        service.ClearAuthentication();

        Assert.Null(service.AuthorizationHeader());
    }

    [Fact]
    public async Task SendRequestAsync_ReturnsSuccessResult()
    {
        var expectedPayload = new TestResponse { Message = "Success" };
        var json = JsonConvert.SerializeObject(expectedPayload);

        var handler = new Mock<HttpMessageHandler>();
        handler.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            });

        var service = CreateService(handler.Object);
        var request = new Request
        {
            HttpMethod = HttpMethod.Get,
            Uri = "/test"
        };

        var result = await service.SendRequestAsync<TestResponse>(request, default);

        Assert.Equal(200, result.StatusCode);
        Assert.Equal(expectedPayload.Message, result.Payload?.Message);
    }

    [Fact]
    public async Task SendRequestAsync_ThrowsOnNonSuccess()
    {
        var handler = new Mock<HttpMessageHandler>();
        var errorJson = JsonConvert.SerializeObject(new TestResult
        {
            Messages = new[] { "Unauthorized access" }
        });

        handler.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.Unauthorized,
                Content = new StringContent(errorJson, Encoding.UTF8, "application/json")
            });

        var service = CreateService(handler.Object);
        var request = new Request
        {
            HttpMethod = HttpMethod.Get,
            Uri = "/test"
        };

        var ex = await Assert.ThrowsAsync<FlowSynxClientException>(() =>
            service.SendRequestAsync<TestResponse>(request, default));

        Assert.Contains("Unauthorized access", ex.Message);
    }
}

public static class HttpRequestServiceExtensions
{
    public static AuthenticationHeaderValue? AuthorizationHeader(this HttpRequestService service)
    {
        var field = typeof(HttpRequestService)
            .GetField("_httpClient", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        var client = (HttpClient)field!.GetValue(service)!;
        return client.DefaultRequestHeaders.Authorization;
    }
}

public class TestResponse
{
    public string? Message { get; set; }
}

public class TestResult
{
    public string[]? Messages { get; set; }
}