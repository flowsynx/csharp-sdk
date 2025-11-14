using FlowSynx.Client.Authentication;

namespace FlowSynx.Client.UnitTests.Authentication;

public class NoAuthenticationStrategyTests
{
    [Fact]
    public async Task ApplyAsync_DoesNotSetAuthorizationHeader()
    {
        // Arrange
        var strategy = new NoAuthenticationStrategy();
        var request = new HttpRequestMessage();

        // Act
        await strategy.ApplyAsync(request);

        // Assert
        Assert.Null(request.Headers.Authorization);
    }

    [Fact]
    public async Task ApplyAsync_DoesNotModifyExistingAuthorizationHeader()
    {
        // Arrange
        var strategy = new NoAuthenticationStrategy();
        var request = new HttpRequestMessage();
        request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "existing-token");

        // Act
        await strategy.ApplyAsync(request);

        // Assert
        Assert.NotNull(request.Headers.Authorization);
        Assert.Equal("Bearer", request.Headers.Authorization.Scheme);
        Assert.Equal("existing-token", request.Headers.Authorization.Parameter);
    }
}