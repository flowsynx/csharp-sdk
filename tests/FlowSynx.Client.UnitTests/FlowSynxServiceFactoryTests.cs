using FlowSynx.Client.Authentication;
using FlowSynx.Client.Http;
using FlowSynx.Client.Services;
using Moq;

namespace FlowSynx.Client.UnitTests;

public class FlowSynxServiceFactoryTests
{
    private readonly Mock<IHttpClientFactory> _httpClientFactoryMock;
    private readonly FlowSynxServiceFactory _factory;

    public FlowSynxServiceFactoryTests()
    {
        _httpClientFactoryMock = new Mock<IHttpClientFactory>();
        _httpClientFactoryMock
            .Setup(f => f.CreateClient(It.IsAny<string>()))
            .Returns(new HttpClient());

        _factory = new FlowSynxServiceFactory(_httpClientFactoryMock.Object);
    }

    [Fact]
    public void Constructor_NullHttpClientFactory_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => new FlowSynxServiceFactory(null));
    }

    [Fact]
    public void CreateHttpRequestService_CreatesServiceWithCorrectBaseAddress()
    {
        // Arrange
        string baseAddress = "https://test.flowsynx.io";
        var authStrategyMock = new Mock<IAuthenticationStrategy>();

        // Act
        var service = _factory.CreateHttpRequestHandler(baseAddress, authStrategyMock.Object);

        // Assert
        Assert.NotNull(service);
        Assert.IsType<HttpRequestHandler>(service);
    }

    [Fact]
    public void CreateAuditService_ReturnsAuditService()
    {
        var mockHttpRequestService = new Mock<IHttpRequestHandler>();
        var service = _factory.CreateAuditService(mockHttpRequestService.Object);

        Assert.NotNull(service);
        Assert.IsAssignableFrom<IAuditService>(service);
    }

    [Fact]
    public void CreatePluginConfigService_ReturnsPluginConfigService()
    {
        var mockHttpRequestService = new Mock<IHttpRequestHandler>();
        var service = _factory.CreatePluginConfigService(mockHttpRequestService.Object);

        Assert.NotNull(service);
        Assert.IsAssignableFrom<IPluginConfigService>(service);
    }

    [Fact]
    public void CreateLogsService_ReturnsLogsService()
    {
        var mockHttpRequestService = new Mock<IHttpRequestHandler>();
        var service = _factory.CreateLogsService(mockHttpRequestService.Object);

        Assert.NotNull(service);
        Assert.IsAssignableFrom<ILogsService>(service);
    }

    [Fact]
    public void CreatePluginsService_ReturnsPluginsService()
    {
        var mockHttpRequestService = new Mock<IHttpRequestHandler>();
        var service = _factory.CreatePluginsService(mockHttpRequestService.Object);

        Assert.NotNull(service);
        Assert.IsAssignableFrom<IPluginsService>(service);
    }

    [Fact]
    public void CreateWorkflowsService_ReturnsWorkflowsService()
    {
        var mockHttpRequestService = new Mock<IHttpRequestHandler>();
        var service = _factory.CreateWorkflowsService(mockHttpRequestService.Object);

        Assert.NotNull(service);
        Assert.IsAssignableFrom<IWorkflowsService>(service);
    }

    [Fact]
    public void CreateHealthCheckService_ReturnsHealthCheckService()
    {
        var mockHttpRequestService = new Mock<IHttpRequestHandler>();
        var service = _factory.CreateHealthCheckService(mockHttpRequestService.Object);

        Assert.NotNull(service);
        Assert.IsAssignableFrom<IHealthCheckService>(service);
    }

    [Fact]
    public void CreateVersionService_ReturnsVersionService()
    {
        var mockHttpRequestService = new Mock<IHttpRequestHandler>();
        var service = _factory.CreateVersionService(mockHttpRequestService.Object);

        Assert.NotNull(service);
        Assert.IsAssignableFrom<IVersionService>(service);
    }
}