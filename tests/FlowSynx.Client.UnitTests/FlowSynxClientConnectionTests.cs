using FlowSynx.Client.Exceptions;

namespace FlowSynx.Client.UnitTests;

public class FlowSynxClientConnectionTests
{
    [Fact]
    public void Constructor_WithValidHttpUrl_SetsBaseAddress()
    {
        // Arrange
        string validUrl = "https://test.flowsynx.io";

        // Act
        var connection = new FlowSynxClientConnection(validUrl);

        // Assert
        Assert.Equal(validUrl, connection.BaseAddress);
    }

    [Fact]
    public void Constructor_WithValidHttpsUrl_SetsBaseAddress()
    {
        // Arrange
        string validUrl = "https://test.flowsynx.io";

        // Act
        var connection = new FlowSynxClientConnection(validUrl);

        // Assert
        Assert.Equal(validUrl, connection.BaseAddress);
    }

    [Theory]
    [InlineData("ftp://example.com")]
    [InlineData("example.com")]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("not a url")]
    public void Constructor_WithInvalidUrl_ThrowsFlowSynxClientException(string invalidUrl)
    {
        // Act & Assert
        var ex = Assert.Throws<FlowSynxClientException>(() => new FlowSynxClientConnection(invalidUrl));
        Assert.Contains(invalidUrl ?? string.Empty, ex.Message);
    }
}