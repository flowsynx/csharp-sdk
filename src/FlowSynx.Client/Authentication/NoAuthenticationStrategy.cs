namespace FlowSynx.Client.Authentication;

/// <summary>
/// Represents an authentication strategy that applies no authentication to HTTP requests.
/// Implements the <see cref="IAuthenticationStrategy"/> interface.
/// </summary>
public class NoAuthenticationStrategy : IAuthenticationStrategy
{
    /// <summary>
    /// Applies no authentication to the given HTTP request.
    /// This method is a no-op and does not modify the request.
    /// </summary>
    /// <param name="request">The HTTP request to which no authentication will be applied.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public Task ApplyAsync(HttpRequestMessage request) => Task.CompletedTask;
}