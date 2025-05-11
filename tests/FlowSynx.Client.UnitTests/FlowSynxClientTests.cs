using FlowSynx.Client.Http;
using Moq;
using FlowSynx.Client.Authentication;
using FlowSynx.Client.Services;

namespace FlowSynx.Client.UnitTests;

public class FlowSynxClientTests
{
    [Fact]
    public void Constructor_InitializesAllServicesCorrectly()
    {
        // Arrange
        var baseAddress = "https://test.flowsynx.io";
        var mockConnection = new Mock<IFlowSynxClientConnection>();
        mockConnection.Setup(c => c.BaseAddress).Returns(baseAddress);

        var mockAuthStrategy = new Mock<IAuthenticationStrategy>();

        var mockHttpRequestService = new Mock<IHttpRequestHandler>();

        var mockAuditService = new Mock<IAuditService>();
        var mockPluginConfigService = new Mock<IPluginConfigService>();
        var mockLogsService = new Mock<ILogsService>();
        var mockPluginsService = new Mock<IPluginsService>();
        var mockWorkflowsService = new Mock<IWorkflowsService>();
        var mockHealthCheckService = new Mock<IHealthCheckService>();
        var mockVersionService = new Mock<IVersionService>();

        var mockFactory = new Mock<IFlowSynxServiceFactory>();
        mockFactory.Setup(f => f.CreateHttpRequestHandler(baseAddress, mockAuthStrategy.Object)).Returns(mockHttpRequestService.Object);
        mockFactory.Setup(f => f.CreateAuditService(mockHttpRequestService.Object)).Returns(mockAuditService.Object);
        mockFactory.Setup(f => f.CreatePluginConfigService(mockHttpRequestService.Object)).Returns(mockPluginConfigService.Object);
        mockFactory.Setup(f => f.CreateLogsService(mockHttpRequestService.Object)).Returns(mockLogsService.Object);
        mockFactory.Setup(f => f.CreatePluginsService(mockHttpRequestService.Object)).Returns(mockPluginsService.Object);
        mockFactory.Setup(f => f.CreateWorkflowsService(mockHttpRequestService.Object)).Returns(mockWorkflowsService.Object);
        mockFactory.Setup(f => f.CreateHealthCheckService(mockHttpRequestService.Object)).Returns(mockHealthCheckService.Object);
        mockFactory.Setup(f => f.CreateVersionService(mockHttpRequestService.Object)).Returns(mockVersionService.Object);

        // Act
        var client = new FlowSynxClient(mockConnection.Object, mockAuthStrategy.Object, mockFactory.Object);

        // Assert
        Assert.Equal(mockAuditService.Object, client.Audits);
        Assert.Equal(mockPluginConfigService.Object, client.PluginConfig);
        Assert.Equal(mockLogsService.Object, client.Logs);
        Assert.Equal(mockPluginsService.Object, client.Plugins);
        Assert.Equal(mockWorkflowsService.Object, client.Workflows);
        Assert.Equal(mockHealthCheckService.Object, client.HealthCheck);
        Assert.Equal(mockVersionService.Object, client.Version);

        mockFactory.Verify(f => f.CreateHttpRequestHandler(baseAddress, mockAuthStrategy.Object), Times.Once);
        mockFactory.Verify(f => f.CreateAuditService(mockHttpRequestService.Object), Times.Once);
        mockFactory.Verify(f => f.CreatePluginConfigService(mockHttpRequestService.Object), Times.Once);
        mockFactory.Verify(f => f.CreateLogsService(mockHttpRequestService.Object), Times.Once);
        mockFactory.Verify(f => f.CreatePluginsService(mockHttpRequestService.Object), Times.Once);
        mockFactory.Verify(f => f.CreateWorkflowsService(mockHttpRequestService.Object), Times.Once);
        mockFactory.Verify(f => f.CreateHealthCheckService(mockHttpRequestService.Object), Times.Once);
        mockFactory.Verify(f => f.CreateVersionService(mockHttpRequestService.Object), Times.Once);
    }
}
