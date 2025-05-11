//using FlowSynx.Client.Authentication;
//using FlowSynx.Client.Exceptions;
//using FlowSynx.Client.Http;
//using FlowSynx.Client.Messages.Requests;
//using FlowSynx.Client.Messages.Responses;
//using Moq;
//using Moq.Protected;
//using Newtonsoft.Json;
//using System.Net;
//using System.Text;

//namespace FlowSynx.Client.UnitTests.Http;

//public class HttpRequestServiceTests
//{
//    private readonly Mock<IAuthenticationStrategy> _mockAuthStrategy;
//    private readonly Mock<IFlowSynxClientConnection> _mockConnection;
//    private readonly HttpClient _httpClient;
//    private readonly HttpRequestService _service;

//    public HttpRequestServiceTests()
//    {
//        _mockAuthStrategy = new Mock<IAuthenticationStrategy>();
//        _mockConnection = new Mock<IFlowSynxClientConnection>();
//        _mockConnection.Setup(x => x.BaseAddress).Returns("http://localhost");

//        // Set up mocked HttpClient using a real DelegatingHandler
//        var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
//        _httpClient = new HttpClient(handlerMock.Object) { BaseAddress = new Uri("http://localhost") };

//        // Set up the service with injected HttpClient
//        _service = new HttpRequestService(_mockConnection.Object, _mockAuthStrategy.Object);
//    }

//    [Fact]
//    public async Task SendRequestAsync_ShouldReturnDeserializedResult_WhenResponseIsSuccessful()
//    {
//        // Arrange
//        var expectedPayload = new TestResponse { Message = "OK" };
//        var responseJson = JsonConvert.SerializeObject(expectedPayload);

//        var handlerMock = GetMockedHandler(HttpStatusCode.OK, responseJson);
//        var httpClient = new HttpClient(handlerMock.Object) { BaseAddress = new Uri("http://localhost") };

//        var service = new HttpRequestService(_mockConnection.Object, _mockAuthStrategy.Object);
//        var request = new Request
//        {
//            HttpMethod = HttpMethod.Get,
//            Uri = "/test",
//            MediaType = "application/json",
//            Headers = new Dictionary<string, string>()
//        };

//        // Act
//        var result = await service.SendRequestAsync<TestResponse>(request, CancellationToken.None);

//        // Assert
//        Assert.Equal(200, result.StatusCode);
//        Assert.Equal("OK", result.Payload.Message);
//    }

//    [Fact]
//    public async Task SendRequestAsync_ShouldThrowFlowSynxClientException_OnDeserializationError()
//    {
//        // Arrange
//        var invalidJson = "invalid json";
//        var handlerMock = GetMockedHandler(HttpStatusCode.OK, invalidJson);
//        var httpClient = new HttpClient(handlerMock.Object) { BaseAddress = new Uri("http://localhost") };

//        var service = new TestableHttpRequestService(_mockConnection.Object, _mockAuthStrategy.Object);
//        var request = new Request
//        {
//            HttpMethod = HttpMethod.Get,
//            Uri = "/test",
//            MediaType = "application/json",
//            Headers = new Dictionary<string, string>()
//        };

//        // Act & Assert
//        await Assert.ThrowsAsync<FlowSynxClientException>(() =>
//            service.SendRequestAsync<TestResponse>(request, CancellationToken.None));
//    }

//    [Fact]
//    public async Task SendRequestAsync_ShouldThrowFlowSynxClientException_WhenResponseIsFailure()
//    {
//        // Arrange
//        var errorResponse = JsonConvert.SerializeObject(new Result
//        {
//            Messages = new List<string> { "Bad Request" }
//        });

//        var handlerMock = GetMockedHandler(HttpStatusCode.BadRequest, errorResponse);
//        var httpClient = new HttpClient(handlerMock.Object) { BaseAddress = new Uri("http://localhost") };

//        var service = new TestableHttpRequestService(_mockConnection.Object, _mockAuthStrategy.Object);
//        var request = new Request
//        {
//            HttpMethod = HttpMethod.Get,
//            Uri = "/test",
//            MediaType = "application/json",
//            Headers = new Dictionary<string, string>()
//        };

//        // Act & Assert
//        var ex = await Assert.ThrowsAsync<FlowSynxClientException>(() =>
//            service.SendRequestAsync<TestResponse>(request, CancellationToken.None));

//        Assert.Contains("Bad Request", ex.Message);
//    }

//    // Helper to mock HttpMessageHandler
//    private Mock<HttpMessageHandler> GetMockedHandler(HttpStatusCode statusCode, string content)
//    {
//        var handler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
//        handler.Protected()
//            .Setup<Task<HttpResponseMessage>>("SendAsync",
//                ItExpr.IsAny<HttpRequestMessage>(),
//                ItExpr.IsAny<CancellationToken>())
//            .ReturnsAsync(new HttpResponseMessage
//            {
//                StatusCode = statusCode,
//                Content = new StringContent(content, Encoding.UTF8, "application/json")
//            });

//        return handler;
//    }

//    // Dummy class to test deserialization
//    public class TestResponse
//    {
//        public string Message { get; set; } = "";
//    }
//}