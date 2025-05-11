using FlowSynx.Client.Authentication;
using System.Text;

namespace FlowSynx.Client.UnitTests.Authentication;

public class BasicAuthenticationStrategyTests
{
    [Fact]
    public async Task ApplyAsync_SetsAuthorizationHeaderWithBasicScheme()
    {
        // Arrange
        var username = "testuser";
        var password = "testpass";
        var strategy = new BasicAuthenticationStrategy(username, password);
        var request = new HttpRequestMessage();

        // Act
        await strategy.ApplyAsync(request);

        // Assert
        Assert.NotNull(request.Headers.Authorization);
        Assert.Equal("Basic", request.Headers.Authorization.Scheme);

        var expectedCredentials = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{username}:{password}"));
        Assert.Equal(expectedCredentials, request.Headers.Authorization.Parameter);
    }

    [Fact]
    public async Task ApplyAsync_WithEmptyUsernameAndPassword_SetsAuthorizationHeader()
    {
        // Arrange
        var strategy = new BasicAuthenticationStrategy("", "");
        var request = new HttpRequestMessage();

        // Act
        await strategy.ApplyAsync(request);

        // Assert
        Assert.NotNull(request.Headers.Authorization);
        Assert.Equal("Basic", request.Headers.Authorization.Scheme);

        var expectedCredentials = Convert.ToBase64String(Encoding.UTF8.GetBytes(":"));
        Assert.Equal(expectedCredentials, request.Headers.Authorization.Parameter);
    }
}