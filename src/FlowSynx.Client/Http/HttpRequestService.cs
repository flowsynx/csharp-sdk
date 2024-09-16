using System.Net;
using FlowSynx.Client.Exceptions;
using FlowSynx.Client.Requests;
using System.Net.Http.Headers;
using System.Text;
using FlowSynx.Client.Responses;
using Newtonsoft.Json;

namespace FlowSynx.Client.Http;

internal class HttpRequestService : IHttpRequestService
{
    private readonly HttpClient _httpClient;

    internal HttpRequestService(string baseAddress)
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri(baseAddress);
    }

    public static HttpRequestService Create(string baseAddress)
    {
        return new HttpRequestService(baseAddress);
    }
    
    public async Task<HttpResult<TResult>> SendRequestAsync<TResult>(Request request, CancellationToken cancellationToken)
    {
        try
        {
            var response = await CreateHttpRequestAsync(request, cancellationToken).ConfigureAwait(false);
            var headers = response.Headers.Concat(response.Content.Headers);
            var responseContent = response.Content;
            var responseString = await responseContent.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
            var deserialized = JsonConvert.DeserializeObject<TResult>(responseString);
            if (deserialized == null)
                throw new FlowSynxClientException(Resources.PayloadCouldNotBeDeserialized);

            return new HttpResult<TResult>()
            {
                StatusCode = (int)response.StatusCode,
                Headers = headers,
                Payload = deserialized
            };
        }
        catch (HttpRequestException)
        {
            throw new FlowSynxClientException(Resources.RequestServiceHttpRequestExceptionMessage);
        }
        catch (TimeoutException)
        {
            throw new FlowSynxClientException(Resources.RequestServiceTimeoutException);
        }
        catch (OperationCanceledException)
        {
            throw new FlowSynxClientException(Resources.RequestServiceOperationCanceledException);
        }
        catch (JsonException ex)
        {
            throw new FlowSynxClientException(Resources.PayloadCouldNotBeDeserialized, ex);
        }
        catch (Exception ex)
        {
            throw new FlowSynxClientException(string.Format(Resources.RequestServiceException, ex.Message));
        }
    }

    public async Task<HttpResult<TResult>> SendRequestAsync<TRequest, TResult>(Request<TRequest> request, CancellationToken cancellationToken)
    {
        try
        {
            var response = await CreateHttpRequestAsync(request, cancellationToken).ConfigureAwait(false);
            var headers = response.Headers.Concat(response.Content.Headers);
            var responseContent = response.Content;
            var responseString = await responseContent.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
            var deserialized = JsonConvert.DeserializeObject<TResult>(responseString);
            if (deserialized == null)
                throw new FlowSynxClientException(Resources.PayloadCouldNotBeDeserialized);

            return new HttpResult<TResult>()
            {
                StatusCode = (int)response.StatusCode,
                Headers = headers,
                Payload = deserialized
            };
        }
        catch (HttpRequestException)
        {
            throw new FlowSynxClientException(Resources.RequestServiceHttpRequestExceptionMessage);
        }
        catch (TimeoutException)
        {
            throw new FlowSynxClientException(Resources.RequestServiceTimeoutException);
        }
        catch (OperationCanceledException)
        {
            throw new FlowSynxClientException(Resources.RequestServiceOperationCanceledException);
        }
        catch (JsonException ex)
        {
            throw new FlowSynxClientException(Resources.PayloadCouldNotBeDeserialized, ex);
        }
        catch (Exception ex)
        {
            throw new FlowSynxClientException(string.Format(Resources.RequestServiceException, ex.Message));
        }
    }

    public async Task<HttpResult<Stream>> SendRequestAsync<TRequest>(Request<TRequest> request, CancellationToken cancellationToken)
    {
        try
        {
            var response = await CreateHttpRequestAsync(request, cancellationToken).ConfigureAwait(false);
            var headers = response.Headers.Concat(response.Content.Headers);
            var responseStream = await response.Content.ReadAsStreamAsync(cancellationToken);

            return new HttpResult<Stream>()
            {
                StatusCode = (int)response.StatusCode,
                Headers = headers,
                Payload = responseStream
            };
        }
        catch (HttpRequestException)
        {
            throw new FlowSynxClientException(Resources.RequestServiceHttpRequestExceptionMessage);
        }
        catch (TimeoutException)
        {
            throw new FlowSynxClientException(Resources.RequestServiceTimeoutException);
        }
        catch (OperationCanceledException)
        {
            throw new FlowSynxClientException(Resources.RequestServiceOperationCanceledException);
        }
        catch (JsonException ex)
        {
            throw new FlowSynxClientException(Resources.PayloadCouldNotBeDeserialized, ex);
        }
        catch (Exception ex)
        {
            throw new FlowSynxClientException(string.Format(Resources.RequestServiceException, ex.Message));
        }
    }

    public async Task<HttpResult<Stream>> SendRequestAsync(Request request, CancellationToken cancellationToken)
    {
        try
        {
            var response = await CreateHttpRequestAsync(request, cancellationToken).ConfigureAwait(false);
            var headers = response.Headers.Concat(response.Content.Headers);
            var responseStream = await response.Content.ReadAsStreamAsync(cancellationToken);

            return new HttpResult<Stream>()
            {
                StatusCode = (int)response.StatusCode,
                Headers = headers,
                Payload = responseStream
            };
        }
        catch (HttpRequestException)
        {
            throw new FlowSynxClientException(Resources.RequestServiceHttpRequestExceptionMessage);
        }
        catch (TimeoutException)
        {
            throw new FlowSynxClientException(Resources.RequestServiceTimeoutException);
        }
        catch (OperationCanceledException)
        {
            throw new FlowSynxClientException(Resources.RequestServiceOperationCanceledException);
        }
        catch (JsonException ex)
        {
            throw new FlowSynxClientException(Resources.PayloadCouldNotBeDeserialized, ex);
        }
        catch (Exception ex)
        {
            throw new FlowSynxClientException(string.Format(Resources.RequestServiceException, ex.Message));
        }
    }

    #region private methods
    private async Task<HttpResponseMessage> CreateHttpRequestAsync<TRequest>(Request<TRequest> request, CancellationToken cancellationToken)
    {
        var message = new HttpRequestMessage(request.HttpMethod, request.Uri);

        if (!string.IsNullOrEmpty(request.MediaType))
            AddMediaTypeHeader(message.Headers, request.MediaType);

        if (request.Headers.Count > 0)
            AddHeaders(message.Headers, request.Headers);

        if (request.Content != null)
            message.Content = new StringContent(JsonConvert.SerializeObject(request.Content), Encoding.UTF8, request.MediaType);

        return await _httpClient.SendAsync(message, cancellationToken);
    }

    private async Task<HttpResponseMessage> CreateHttpRequestAsync(Request request, CancellationToken cancellationToken)
    {
        var message = new HttpRequestMessage(request.HttpMethod, request.Uri);

        if (!string.IsNullOrEmpty(request.MediaType))
            AddMediaTypeHeader(message.Headers, request.MediaType);

        if (request.Headers.Count > 0)
            AddHeaders(message.Headers, request.Headers);

        return await _httpClient.SendAsync(message, cancellationToken);
    }

    private void AddMediaTypeHeader(HttpRequestHeaders requestHeader, string mediaType)
    {
        requestHeader.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));
    }

    private void AddHeaders(HttpRequestHeaders requestHeader, IDictionary<string, string> headers)
    {
        foreach (var header in headers)
            requestHeader.Add(header.Key, header.Value);
    }
    #endregion
    
    public void Dispose()
    {
        _httpClient.Dispose();
    }
}