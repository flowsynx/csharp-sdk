using FlowSynx.Client.Authentication;
using FlowSynx.Client.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FlowSynx.Client.AspNetCore.UnitTests;

public class FlowSynxServiceCollectionExtensionsTests
{
    [Fact]
    public void AddFlowSynxClient_Throws_If_Services_Null()
    {
        // Arrange
        IServiceCollection? services = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() =>
            FlowSynxServiceCollectionExtensions.AddFlowSynxClient(services!, options => { }));
    }

    [Fact]
    public void AddFlowSynxClient_Throws_If_Configure_Null()
    {
        // Arrange
        var services = new ServiceCollection();

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() =>
            FlowSynxServiceCollectionExtensions.AddFlowSynxClient(services, null!));
    }

    [Fact]
    public void AddFlowSynxClient_Skips_If_Already_Registered()
    {
        // Arrange
        var services = new ServiceCollection();
        services.AddScoped<IFlowSynxClient, DummyFlowSynxClient>();

        // Act
        FlowSynxServiceCollectionExtensions.AddFlowSynxClient(services, options => { });

        // Assert
        var count = services.Count(sd => sd.ServiceType == typeof(IFlowSynxClient));
        Assert.Equal(1, count);
    }

    [Theory]
    [InlineData(AuthenticationType.Basic)]
    [InlineData(AuthenticationType.BearerToken)]
    public void AddFlowSynxClient_Registers_Dependencies_Correctly(AuthenticationType authType)
    {
        // Arrange
        var services = new ServiceCollection();

        FlowSynxServiceCollectionExtensions.AddFlowSynxClient(services, options =>
        {
            options.AuthenticationType = authType;
            options.Username = "user";
            options.Password = "pass";
            options.BearerToken = "token";
            options.BaseUrl = "https://test.flowsynx.io";
        });

        var provider = services.BuildServiceProvider();

        // Act
        var client = provider.GetService<IFlowSynxClient>();
        var auth = provider.GetService<IAuthenticationStrategy>();
        var factory = provider.GetService<IFlowSynxServiceFactory>();
        var connection = provider.GetService<IFlowSynxClientConnection>();

        // Assert
        Assert.NotNull(client);
        Assert.NotNull(auth);
        Assert.NotNull(factory);
        Assert.NotNull(connection);
        Assert.IsType<FlowSynxClient>(client);
        Assert.IsType<FlowSynxClientConnection>(connection);

        if (authType == AuthenticationType.Basic)
            Assert.IsType<BasicAuthenticationStrategy>(auth);
        else if (authType == AuthenticationType.BearerToken)
            Assert.IsType<BearerTokenAuthStrategy>(auth);
    }

    [Fact]
    public void AddFlowSynxClient_Throws_For_Unsupported_AuthenticationType()
    {
        // Arrange
        var services = new ServiceCollection();

        FlowSynxServiceCollectionExtensions.AddFlowSynxClient(services, options =>
        {
            options.AuthenticationType = (AuthenticationType)999;
        });

        var provider = services.BuildServiceProvider();

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() =>
        {
            var _ = provider.GetRequiredService<IAuthenticationStrategy>();
        });
    }

    // Dummy implementation just for testing registration short-circuit
    private class DummyFlowSynxClient : IFlowSynxClient
    {
        public void SetConnection(IFlowSynxClientConnection connection)
        {
            throw new NotImplementedException();
        }

        public void SetAuthenticationStrategy(IAuthenticationStrategy strategy)
        {
            throw new NotImplementedException();
        }

        public IAuditService Audits => throw new NotImplementedException();

        public IPluginConfigService PluginConfig => throw new NotImplementedException();

        public ILogsService Logs => throw new NotImplementedException();

        public IMetricsService Metrics => throw new NotImplementedException();

        public IPluginsService Plugins => throw new NotImplementedException();

        public IWorkflowsService Workflows => throw new NotImplementedException();

        public IHealthCheckService HealthCheck => throw new NotImplementedException();

        public IVersionService Version => throw new NotImplementedException();
    }
}