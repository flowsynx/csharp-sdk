using FlowSynx.Client.Exceptions;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using FlowSynx.Client.Authentication;
using FlowSynx.Client.Messages.Responses;
using FlowSynx.Client.Messages.Requests;

namespace FlowSynx.Client.Http;

public class HttpRequestHandler : IHttpRequestHandler
{
    private readonly HttpClient _httpClient;
    private readonly object _connLock = new();
    private readonly object _authLock = new();
    private IAuthenticationStrategy _authenticationStrategy;

    public HttpRequestHandler(HttpClient httpClient, IAuthenticationStrategy authenticationStrategy)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        _authenticationStrategy = authenticationStrategy ?? throw new ArgumentNullException(nameof(authenticationStrategy));
    }

    public void SetHttpConnection(IFlowSynxClientConnection connection)
    {
        if (connection == null) throw new ArgumentNullException(nameof(connection));
        lock (_connLock)
        {
            _httpClient.BaseAddress = new Uri(connection.BaseAddress);
        }
    }

    public void SetAuthenticationStrategy(IAuthenticationStrategy strategy)
    {
        if (strategy == null) throw new ArgumentNullException(nameof(strategy));
        lock (_authLock)
        {
            _authenticationStrategy = strategy;
        }
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
            IAuthenticationStrategy strategy;
            lock (_authLock)
            {
                strategy = _authenticationStrategy;
            }

            await strategy.ApplyAsync(message);

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
            string serialized;

            if (content is string s && (s.TrimStart().StartsWith("{") || s.TrimStart().StartsWith("[")))
                serialized = s;
            else
                serialized = JsonConvert.SerializeObject(content);

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