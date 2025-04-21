using FlowSynx.Client.Exceptions;
using FlowSynx.Client.Requests;
using System.Net.Http.Headers;
using System.Text;
using FlowSynx.Client.Responses;
using Newtonsoft.Json;

namespace FlowSynx.Client.Http;

public class HttpRequestService : IHttpRequestService
{
    private readonly HttpClient _httpClient;

    protected HttpRequestService(string baseAddress) =>
        _httpClient = new HttpClient { BaseAddress = new Uri(baseAddress) };

    public static HttpRequestService Create(string baseAddress) => new(baseAddress);

    public void UseBasicAuth(string username, string password)
    {
        var credentials = $"{username}:{password}";
        var base64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(credentials));
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", base64);
    }

    public void UseBearerToken(string token) =>
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

    public void ClearAuthentication() =>
        _httpClient.DefaultRequestHeaders.Authorization = null;

    public async Task<HttpResult<TResult>> SendRequestAsync<TResult>(Request request, CancellationToken cancellationToken)
    {
        var message = BuildHttpRequestMessage<object>(request.HttpMethod, request.Uri, request.MediaType, request.Headers, null);
        return await SendInternalRequestAsync<TResult>(message, cancellationToken);
    }
    public async Task<HttpResult<TResult>> SendRequestAsync<TRequest, TResult>(Request<TRequest> request,
        CancellationToken cancellationToken)
    {
        var message = BuildHttpRequestMessage(request.HttpMethod, request.Uri, request.MediaType, request.Headers, request.Content);
        return await SendInternalRequestAsync<TResult>(message, cancellationToken);
    }
    
    protected async Task<HttpResult<TResult>> SendInternalRequestAsync<TResult>(HttpRequestMessage message, CancellationToken cancellationToken)
    {
        try
        {
            var response = await _httpClient.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var body = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
                throw new FlowSynxClientException(GetStatusCodeMessageAsync(body));

            var deserializedPayload = JsonConvert.DeserializeObject<TResult>(body)
                ?? throw new FlowSynxClientException(
                    Resources.HttpRequest_OperationFailed_PayloadCouldNotDeserialized);

            return new HttpResult<TResult>()
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

    #region private methods
    protected HttpRequestMessage BuildHttpRequestMessage<TRequest>(HttpMethod method,
        string uri, string? mediaType, IDictionary<string, string> headers, TRequest? content)
    {
        var message = new HttpRequestMessage(method, uri);

        if (!string.IsNullOrWhiteSpace(mediaType))
            message.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));

        foreach (var header in headers)
            message.Headers.TryAddWithoutValidation(header.Key, header.Value);

        if (content is not null)
        {
            var serialized = JsonConvert.SerializeObject(content);
            message.Content = new StringContent(serialized, Encoding.UTF8, mediaType ?? "application/json");
        }

        return message;
    }

    protected string GetStatusCodeMessageAsync(string content)
    {
        try
        {
            var deserialized = JsonConvert.DeserializeObject<Result>(content);
            return deserialized?.Messages != null && deserialized.Messages.Count != 0
                ? string.Join(Environment.NewLine, deserialized.Messages)
                : content;
        }
        catch
        {
            return content;
        }
    }
    #endregion

    public void Dispose() => _httpClient.Dispose();
}