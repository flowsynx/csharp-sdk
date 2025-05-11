using System.Net.Http.Headers;
using System.Text;

namespace FlowSynx.Client.Authentication;

/// <summary>
/// Represents an authentication strategy that applies Basic Authentication to HTTP requests.
/// Implements the <see cref="IAuthenticationStrategy"/> interface.
/// </summary>
public class BasicAuthenticationStrategy : IAuthenticationStrategy
{
    private readonly string _username;
    private readonly string _password;

    /// <summary>
    /// Initializes a new instance of the <see cref="BasicAuthenticationStrategy"/> class with the specified username and password.
    /// </summary>
    /// <param name="username">The username for Basic Authentication.</param>
    /// <param name="password">The password for Basic Authentication.</param>
    public BasicAuthenticationStrategy(string username, string password)
    {
        _username = username;
        _password = password;
    }

    /// <summary>
    /// Applies the Basic Authentication credentials to the given HTTP request by adding the Authorization header.
    /// </summary>
    /// <param name="request">The HTTP request to which the Basic Authentication credentials will be applied.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public Task ApplyAsync(HttpRequestMessage request)
    {
        var credentials = Encoding.UTF8.GetBytes($"{_username}:{_password}");
        var base64Credentials = Convert.ToBase64String(credentials);

        request.Headers.Authorization = new AuthenticationHeaderValue("Basic", base64Credentials);
        return Task.CompletedTask;
    }
}