using FlowSynx.Client.Messages.Requests;
using FlowSynx.Client.Messages.Responses;

namespace FlowSynx.Client.Http;

public interface IHttpRequestService
{
    Task<HttpResult<TResult>> SendRequestAsync<TResult>(Request request, CancellationToken cancellationToken);
    Task<HttpResult<TResult>> SendRequestAsync<TRequest, TResult>(Request<TRequest> request, CancellationToken cancellationToken);
}