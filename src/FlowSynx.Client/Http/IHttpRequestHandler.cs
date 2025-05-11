using FlowSynx.Client.Authentication;
using FlowSynx.Client.Messages.Requests;
using FlowSynx.Client.Messages.Responses;

namespace FlowSynx.Client.Http;

/// <summary>
/// Interface for handling HTTP requests with customizable authentication strategies.
/// </summary>
public interface IHttpRequestHandler
{
    /// <summary>
    /// Sets the HTTP connection configuration for the FlowSynx client.
    /// </summary>
    /// <param name="connection">The connection to be used for requests.</param>
    void SetHttpConnection(IFlowSynxClientConnection connection);

    /// <summary>
    /// Sets the authentication strategy for the HTTP request handler.
    /// </summary>
    /// <param name="strategy">The authentication strategy to be used for requests.</param>
    void SetAuthenticationStrategy(IAuthenticationStrategy strategy);

    /// <summary>
    /// Sends an HTTP request and returns the result asynchronously.
    /// </summary>
    /// <typeparam name="TResult">The type of the expected result from the HTTP request.</typeparam>
    /// <param name="request">The request to be sent.</param>
    /// <param name="cancellationToken">A token to cancel the operation if needed.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains an <see cref="HttpResult{TResult}"/> representing the HTTP response.</returns>
    Task<HttpResult<TResult>> SendRequestAsync<TResult>(Request request, CancellationToken cancellationToken);

    /// <summary>
    /// Sends an HTTP request with a typed request body and returns the result asynchronously.
    /// </summary>
    /// <typeparam name="TRequest">The type of the request body.</typeparam>
    /// <typeparam name="TResult">The type of the expected result from the HTTP request.</typeparam>
    /// <param name="request">The typed request to be sent.</param>
    /// <param name="cancellationToken">A token to cancel the operation if needed.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains an <see cref="HttpResult{TResult}"/> representing the HTTP response.</returns>
    Task<HttpResult<TResult>> SendRequestAsync<TRequest, TResult>(Request<TRequest> request, CancellationToken cancellationToken);
}