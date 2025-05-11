using FlowSynx.Client.Authentication;

namespace FlowSynx.Client.UnitTests.Authentication;

public class BearerTokenAuthStrategyTests
{
    [Fact]
    public async Task ApplyAsync_SetsAuthorizationHeaderWithBearerScheme()
    {
        // Arrange
        var token = "test-token-123";
        var strategy = new BearerTokenAuthStrategy(token);
        var request = new HttpRequestMessage();

        // Act
        await strategy.ApplyAsync(request);

        // Assert
        Assert.NotNull(request.Headers.Authorization);
        Assert.Equal("Bearer", request.Headers.Authorization.Scheme);
        Assert.Equal(token, request.Headers.Authorization.Parameter);
    }

    [Fact]
    public async Task ApplyAsync_WithEmptyToken_SetsBearerSchemeWithEmptyParameter()
    {
        // Arrange
        var strategy = new BearerTokenAuthStrategy(string.Empty);
        var request = new HttpRequestMessage();

        // Act
        await strategy.ApplyAsync(request);

        // Assert
        Assert.NotNull(request.Headers.Authorization);
        Assert.Equal("Bearer", request.Headers.Authorization.Scheme);
        Assert.Equal(string.Empty, request.Headers.Authorization.Parameter);
    }
}