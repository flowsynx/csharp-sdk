using FlowSynx.Client.Exceptions;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using FlowSynx.Client.Authentication;
using FlowSynx.Client.Messages.Responses;
using FlowSynx.Client.Messages.Requests;

namespace FlowSynx.Client.Http;

public class HttpRequestService : IHttpRequestService
{
    private readonly HttpClient _httpClient;
    private readonly IAuthenticationStrategy _authenticationStrategy;

    public HttpRequestService(HttpClient httpClient, IAuthenticationStrategy authenticationStrategy)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        _authenticationStrategy = authenticationStrategy ?? throw new ArgumentNullException(nameof(authenticationStrategy));
    }

    public async Task<HttpResult<TResult>> SendRequestAsync<TResult>(Request request, CancellationToken cancellationToken)
    {
        var message = BuildHttpRequestMessage<object>(request.HttpMethod, request.Uri, request.MediaType, request.Headers, null);
        return await SendInternalRequestAsync<TResult>(message, cancellationToken);
    }

    public async Task<HttpResult<TResult>> SendRequestAsync<TRequest, TResult>(Request<TRequest> request, CancellationToken cancellationToken)
    {
        var message = BuildHttpRequestMessage(request.HttpMethod, request.Uri, request.MediaType, request.Headers, request.Content);
        return await SendInternalRequestAsync<TResult>(message, cancellationToken);
    }

    private async Task<HttpResult<TResult>> SendInternalRequestAsync<TResult>(HttpRequestMessage message, CancellationToken cancellationToken)
    {
        try
        {
            await _authenticationStrategy.ApplyAsync(message);

            using var response = await _httpClient.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var responseBody = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
                throw new FlowSynxClientException(ExtractErrorMessage(responseBody));
            
            var deserializedPayload = JsonConvert.DeserializeObject<TResult>(responseBody);
            if (deserializedPayload == null)
                throw new FlowSynxClientException(Resources.HttpRequest_OperationFailed_PayloadCouldNotDeserialized);

            return new HttpResult<TResult>
            {
                StatusCode = (int)response.StatusCode,
                Headers = response.Headers.Concat(response.Content.Headers),
                Payload = deserializedPayload
            };
        }
        catch (Exception ex) when (ex is HttpRequestException or TimeoutException or OperationCanceledException or JsonException)
        {
            throw new FlowSynxClientException(Resources.HttpRequest_RequestFailed, ex);
        }
    }

    private HttpRequestMessage BuildHttpRequestMessage<TRequest>(
        HttpMethod method, string uri, string? mediaType,
        IDictionary<string, string> headers, TRequest? content)
    {
        var message = new HttpRequestMessage(method, uri);

        if (!string.IsNullOrWhiteSpace(mediaType))
            message.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));

        foreach (var header in headers)
            message.Headers.TryAddWithoutValidation(header.Key, header.Value);

        if (content != null)
        {
            var serialized = JsonConvert.SerializeObject(content);
            message.Content = new StringContent(serialized, Encoding.UTF8, mediaType ?? "application/json");
        }

        return message;
    }

    private string ExtractErrorMessage(string content)
    {
        try
        {
            var result = JsonConvert.DeserializeObject<Result>(content);
            return result?.Messages?.Count > 0
                ? string.Join(Environment.NewLine, result.Messages)
                : content;
        }
        catch
        {
            return content;
        }
    }
}





//public class HttpRequestService : IHttpRequestService
//{
//    private readonly HttpClient _httpClient;
//    private readonly IAuthenticationStrategy _authenticationStrategy;

//    public HttpRequestService(IFlowSynxClientConnection connection, IAuthenticationStrategy authenticationStrategy)
//    {
//        _httpClient = new HttpClient { BaseAddress = new Uri(connection.BaseAddress) };
//        _authenticationStrategy = authenticationStrategy;
//    }

//    public async Task<HttpResult<TResult>> SendRequestAsync<TResult>(Request request, CancellationToken cancellationToken)
//    {
//        var message = BuildHttpRequestMessage<object>(request.HttpMethod, request.Uri, request.MediaType, request.Headers, null);
//        return await SendInternalRequestAsync<TResult>(message, cancellationToken);
//    }
//    public async Task<HttpResult<TResult>> SendRequestAsync<TRequest, TResult>(Request<TRequest> request,
//        CancellationToken cancellationToken)
//    {
//        var message = BuildHttpRequestMessage(request.HttpMethod, request.Uri, request.MediaType, request.Headers, request.Content);
//        return await SendInternalRequestAsync<TResult>(message, cancellationToken);
//    }
    
//    protected async Task<HttpResult<TResult>> SendInternalRequestAsync<TResult>(HttpRequestMessage message, CancellationToken cancellationToken)
//    {
//        try
//        {
//            await _authenticationStrategy.ApplyAsync(message);
//            var response = await _httpClient.SendAsync(message, cancellationToken).ConfigureAwait(false);
//            var body = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);

//            if (!response.IsSuccessStatusCode)
//                throw new FlowSynxClientException(GetStatusCodeMessageAsync(body));

//            var deserializedPayload = JsonConvert.DeserializeObject<TResult>(body)
//                ?? throw new FlowSynxClientException(
//                    Resources.HttpRequest_OperationFailed_PayloadCouldNotDeserialized);

//            return new HttpResult<TResult>()
//            {
//                StatusCode = (int)response.StatusCode,
//                Headers = response.Headers.Concat(response.Content.Headers),
//                Payload = deserializedPayload
//            };
//        }
//        catch (Exception ex) when (ex is HttpRequestException or TimeoutException or OperationCanceledException or JsonException)
//        {
//            throw new FlowSynxClientException(Resources.HttpRequest_RequestFailed, ex);
//        }
//    }

//    #region private methods
//    protected HttpRequestMessage BuildHttpRequestMessage<TRequest>(HttpMethod method,
//        string uri, string? mediaType, IDictionary<string, string> headers, TRequest? content)
//    {
//        var message = new HttpRequestMessage(method, uri);

//        if (!string.IsNullOrWhiteSpace(mediaType))
//            message.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));

//        foreach (var header in headers)
//            message.Headers.TryAddWithoutValidation(header.Key, header.Value);

//        if (content is not null)
//        {
//            var serialized = JsonConvert.SerializeObject(content);
//            message.Content = new StringContent(serialized, Encoding.UTF8, mediaType ?? "application/json");
//        }

//        return message;
//    }

//    protected string GetStatusCodeMessageAsync(string content)
//    {
//        try
//        {
//            var deserialized = JsonConvert.DeserializeObject<Result>(content);
//            return deserialized?.Messages != null && deserialized.Messages.Count != 0
//                ? string.Join(Environment.NewLine, deserialized.Messages)
//                : content;
//        }
//        catch
//        {
//            return content;
//        }
//    }
//    #endregion
//}