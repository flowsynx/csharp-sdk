using FlowSynx.Client.Authentication;
using FlowSynx.Client.Messages.Requests;
using FlowSynx.Client.Messages.Responses;

namespace FlowSynx.Client.Http;

public interface IHttpRequestHandler
{
    void SetAuthenticationStrategy(IAuthenticationStrategy strategy);
    Task<HttpResult<TResult>> SendRequestAsync<TResult>(Request request, CancellationToken cancellationToken);
    Task<HttpResult<TResult>> SendRequestAsync<TRequest, TResult>(Request<TRequest> request, CancellationToken cancellationToken);
}