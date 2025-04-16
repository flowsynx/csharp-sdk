namespace FlowSynx.Client.UnitTests;

public class FlowSynxClientFactoryTests
{
    [Fact]
    public void CreateClient_WithoutAddress_UsesDefaultEndpoint()
    {
        // Arrange
        var factory = new FlowSynxClientFactory();
        var defaultAddress = FlowSynxEnvironments.GetDefaultHttpEndpoint();

        // Act
        var client = factory.CreateClient();

        // Assert
        Assert.NotNull(client);
        Assert.IsType<FlowSynxClient>(client);
        Assert.Equal(defaultAddress, ((FlowSynxClient)client).Connection.BaseAddress);
    }

    [Fact]
    public void CreateClient_WithAddress_UsesProvidedEndpoint()
    {
        // Arrange
        var factory = new FlowSynxClientFactory();
        var customAddress = "https://custom.api/endpoint";

        // Act
        var client = factory.CreateClient(customAddress);

        // Assert
        Assert.NotNull(client);
        Assert.IsType<FlowSynxClient>(client);
        Assert.Equal(customAddress, ((FlowSynxClient)client).Connection.BaseAddress);
    }
}