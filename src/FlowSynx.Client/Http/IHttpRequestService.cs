using FlowSynx.Client.Requests;
using FlowSynx.Client.Responses;

namespace FlowSynx.Client.Http;

public interface IHttpRequestService: IDisposable
{
    void UseBasicAuth(string username, string password);
    void UseBearerToken(string token);
    void ClearAuthentication();
    Task<HttpResult<TResult>> SendRequestAsync<TResult>(Request request, CancellationToken cancellationToken);
    Task<HttpResult<TResult>> SendRequestAsync<TRequest, TResult>(Request<TRequest> request, CancellationToken cancellationToken);
}