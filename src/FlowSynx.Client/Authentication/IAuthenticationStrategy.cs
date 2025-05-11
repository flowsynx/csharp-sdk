namespace FlowSynx.Client.Authentication;

/// <summary>
/// Defines an interface for authentication strategies used to apply authentication information to HTTP requests.
/// </summary>
public interface IAuthenticationStrategy
{
    /// <summary>
    /// Asynchronously applies authentication information to the specified HTTP request.
    /// </summary>
    /// <param name="request">The HTTP request message to which authentication information will be applied.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="request"/> is null.</exception>
    Task ApplyAsync(HttpRequestMessage request);
}