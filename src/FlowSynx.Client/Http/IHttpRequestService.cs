﻿using FlowSynx.Client.Requests;
using FlowSynx.Client.Responses;

namespace FlowSynx.Client.Http;

internal interface IHttpRequestService: IDisposable
{
    Task<HttpResult<TResult>> SendRequestAsync<TResult>(Request request, CancellationToken cancellationToken);
    Task<HttpResult<TResult>> SendRequestAsync<TRequest, TResult>(Request<TRequest> request, CancellationToken cancellationToken);
    Task<HttpResult<byte[]>> SendRequestAsync(Request request, CancellationToken cancellationToken);
    Task<HttpResult<byte[]>> SendRequestAsync<TRequest>(Request<TRequest> request, CancellationToken cancellationToken);
}