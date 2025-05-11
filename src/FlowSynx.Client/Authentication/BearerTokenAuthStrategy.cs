namespace FlowSynx.Client.Authentication;

/// <summary>
/// Represents an authentication strategy that applies a Bearer token to HTTP requests.
/// Implements the <see cref="IAuthenticationStrategy"/> interface.
/// </summary>
public class BearerTokenAuthStrategy : IAuthenticationStrategy
{
    private readonly string _token;

    /// <summary>
    /// Initializes a new instance of the <see cref="BearerTokenAuthStrategy"/> class with the specified Bearer token.
    /// </summary>
    /// <param name="token">The Bearer token to be applied to the HTTP requests.</param>
    public BearerTokenAuthStrategy(string token) => _token = token;

    /// <summary>
    /// Applies the Bearer token to the given HTTP request by adding it to the Authorization header.
    /// </summary>
    /// <param name="request">The HTTP request to which the Bearer token will be applied.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public Task ApplyAsync(HttpRequestMessage request)
    {
        request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _token);
        return Task.CompletedTask;
    }
}