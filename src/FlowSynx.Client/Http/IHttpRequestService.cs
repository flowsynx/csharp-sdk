using FlowSynx.Client.Requests;

namespace FlowSynx.Client.Http;

internal interface IHttpRequestService: IDisposable
{
    Task<TResult> SendRequestAsync<TResult>(Request request, CancellationToken cancellationToken);
    Task<TResult> SendRequestAsync<TRequest, TResult>(Request<TRequest> request, CancellationToken cancellationToken);
    Task<Stream> SendRequestAsync(Request request, CancellationToken cancellationToken);
    Task<Stream> SendRequestAsync<TRequest>(Request<TRequest> request, CancellationToken cancellationToken);
}