using FlowSynx.Client.Http;
using FlowSynx.Client.Requests.PluginConfig;
using FlowSynx.Client.Responses.PluginConfig;
using FlowSynx.Client.Responses;
using Moq;
using FlowSynx.Client.Requests;

namespace FlowSynx.Client.UnitTests;

public class FlowSynxClientTests
{
    private readonly Mock<IHttpRequestService> _httpRequestServiceMock;
    private readonly FlowSynxClient _client;

    public FlowSynxClientTests()
    {
        _httpRequestServiceMock = new Mock<IHttpRequestService>();
        var connection = new FlowSynxClientConnection { BaseAddress = "https://tests.flowsynx.io" };
        _client = new FlowSynxClientTestable(connection, _httpRequestServiceMock.Object);
    }

    [Fact]
    public async Task AddPluginConfig_ShouldSendCorrectRequest()
    {
        // Arrange
        var request = new AddPluginConfigRequest 
        { 
            Name = "test",
            Type = "flowsynx.connectors.test",
            Version = "1.0.0",
        };
        var expectedResponse = new HttpResult<Result<AddPluginConfigResponse>> { Payload = new Result<AddPluginConfigResponse>() };

        _httpRequestServiceMock
            .Setup(x => x.SendRequestAsync<AddPluginConfigRequest, Result<AddPluginConfigResponse>>(
                It.IsAny<Request<AddPluginConfigRequest>>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(expectedResponse);

        // Act
        var result = await _client.AddPluginConfig(request);

        // Assert
        Assert.Equal(expectedResponse, result);
        _httpRequestServiceMock.Verify(x => x.SendRequestAsync<AddPluginConfigRequest, Result<AddPluginConfigResponse>>(
            It.Is<Request<AddPluginConfigRequest>>(r => r.Uri == "config/add" && r.Content == request),
            It.IsAny<CancellationToken>()), Times.Once);
    }
}

public class FlowSynxClientTestable : FlowSynxClient
{
    public FlowSynxClientTestable(FlowSynxClientConnection conn, IHttpRequestService httpRequestService)
        : base(conn)
    {
        var field = typeof(FlowSynxClient).GetField("_httpRequestService", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        field?.SetValue(this, httpRequestService);
    }
}
