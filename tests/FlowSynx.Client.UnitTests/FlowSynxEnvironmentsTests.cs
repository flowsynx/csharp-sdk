namespace FlowSynx.Client.UnitTests;

public class FlowSynxEnvironmentsTests
{
    [Fact]
    public void GetDefaultHttpEndpoint_ReturnsCorrectEndpoint()
    {
        // Act
        var endpoint = FlowSynxEnvironments.GetDefaultHttpEndpoint();

        // Assert
        Assert.Equal("http://localhost:6262", endpoint);
    }

    [Fact]
    public void GetDefaultHttpEndpoint_ReturnsSameValueOnMultipleCalls()
    {
        // Act
        var endpoint1 = FlowSynxEnvironments.GetDefaultHttpEndpoint();
        var endpoint2 = FlowSynxEnvironments.GetDefaultHttpEndpoint();

        // Assert
        Assert.Equal(endpoint1, endpoint2);
        Assert.Same(endpoint1, endpoint2);
    }
}