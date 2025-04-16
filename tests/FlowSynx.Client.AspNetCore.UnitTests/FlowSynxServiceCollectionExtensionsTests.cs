using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace FlowSynx.Client.AspNetCore.UnitTests;

public class FlowSynxServiceCollectionExtensionsTests
{
    public class FlowSynxClientFactory
    {
        public virtual IFlowSynxClient CreateClient() => new Mock<IFlowSynxClient>().Object;
    }

    [Fact]
    public void AddFlowSynxClient_ThrowsArgumentNullException_WhenServicesIsNull()
    {
        // Arrange
        IServiceCollection? services = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() =>
        {
            FlowSynxServiceCollectionExtensions.AddFlowSynxClient(services);
        });
    }

    [Fact]
    public void AddFlowSynxClient_RegistersIFlowSynxClientOnce()
    {
        // Arrange
        var services = new ServiceCollection();

        // Act
        services.AddFlowSynxClient();
        services.AddFlowSynxClient(); // Should not register again

        // Assert
        var serviceCount = services.Where(s => s.ServiceType == typeof(IFlowSynxClient));
        Assert.Single(serviceCount);
    }

    [Fact]
    public void AddFlowSynxClient_ResolvesIFlowSynxClient()
    {
        // Arrange
        var services = new ServiceCollection();

        // Act
        services.AddFlowSynxClient();
        var provider = services.BuildServiceProvider();
        var client = provider.GetService<IFlowSynxClient>();

        // Assert
        Assert.NotNull(client);
        Assert.IsAssignableFrom<IFlowSynxClient>(client);
    }
}