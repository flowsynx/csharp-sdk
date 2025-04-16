using FlowSynx.Client.Responses;

namespace FlowSynx.Client.UnitTests.Responses;

public class HttpResultTests
{
    [Fact]
    public void Constructor_WithPayload_SetsPropertiesCorrectly()
    {
        // Arrange
        var expectedPayload = "Success!";
        var expectedStatusCode = 200;
        var expectedHeaders = new List<KeyValuePair<string, IEnumerable<string>>>
        {
            new KeyValuePair<string, IEnumerable<string>>("Content-Type", new[] { "application/json" })
        };

        // Act
        var result = new HttpResult<string>
        {
            StatusCode = expectedStatusCode,
            Headers = expectedHeaders,
            Payload = expectedPayload
        };

        // Assert
        Assert.Equal(expectedStatusCode, result.StatusCode);
        Assert.Equal(expectedHeaders, result.Headers);
        Assert.Equal(expectedPayload, result.Payload);
    }

    [Fact]
    public void DefaultHeaders_ShouldBeInitialized()
    {
        // Act
        var result = new HttpResult<string> { Payload = "Test" };

        // Assert
        Assert.NotNull(result.Headers);
        Assert.Empty(result.Headers);
    }

    [Fact]
    public void SettingPayload_ShouldRequireNonNullValue()
    {
        // Act & Assert
        var result = new HttpResult<string> { Payload = "data" };
        Assert.Equal("data", result.Payload);
    }
}