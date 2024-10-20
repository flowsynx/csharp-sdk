using FlowSynx.Client.Exceptions;
using FlowSynx.Client.Http;
using FlowSynx.Client.Requests;
using FlowSynx.Client.Requests.Config;
using FlowSynx.Client.Requests.Logs;
using FlowSynx.Client.Requests.Connectors;
using FlowSynx.Client.Responses;
using FlowSynx.Client.Responses.Config;
using FlowSynx.Client.Responses.Health;
using FlowSynx.Client.Responses.Version;
using FlowSynx.Client.Responses.Connectors;

namespace FlowSynx.Client;

public class FlowSynxClient : IFlowSynxClient
{
    private IHttpRequestService _httpRequestService;

    public FlowSynxClient(FlowSynxClientConnection clientConnection)
    {
        var baseAddress = clientConnection.BaseAddress;
        if (string.IsNullOrEmpty(baseAddress))
            baseAddress = FlowSynxEnvironments.GetDefaultHttpEndpoint();

        CheckAddress(baseAddress);
        _httpRequestService = HttpRequestService.Create(baseAddress);
    }

    public void ChangeConnection(string baseAddress)
    {
        CheckAddress(baseAddress);
        _httpRequestService = HttpRequestService.Create(baseAddress);
    }

    #region private methods
    private void CheckAddress(string baseAddress)
    {
        if (!IsUrlValid(baseAddress))
            throw new FlowSynxClientException($"Entered address {baseAddress} is not valid. Please check it and try again!");
    }

    private bool IsUrlValid(string url) => Uri.TryCreate(url, UriKind.Absolute, out var uriResult)
                                           && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
    #endregion

    #region Configuration
    public async Task<HttpResult<Result<AddConfigResponse>>> AddConfig(AddConfigRequest request, CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request<AddConfigRequest>
        {
            HttpMethod = HttpMethod.Post,
            Uri = "config/add",
            Content = request
        };

        return await _httpRequestService.SendRequestAsync<AddConfigRequest, Result<AddConfigResponse>>(requestMessage, cancellationToken);
    }

    public async Task<HttpResult<Result<ConfigDetailsResponse>>> ConfigDetails(ConfigDetailsRequest request, CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request<ConfigDetailsRequest>
        {
            HttpMethod = HttpMethod.Post,
            Uri = "config/details",
            Content = request
        };

        return await _httpRequestService.SendRequestAsync<ConfigDetailsRequest, Result<ConfigDetailsResponse>>(requestMessage, cancellationToken);
    }

    public async Task<HttpResult<Result<IEnumerable<object>>>> ConfigList(ConfigListRequest request, CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request<ConfigListRequest>
        {
            HttpMethod = HttpMethod.Post,
            Uri = "config",
            Content = request
        };

        return await _httpRequestService.SendRequestAsync<ConfigListRequest, Result<IEnumerable<object>>>(requestMessage, cancellationToken);
    }

    public async Task<HttpResult<Result<IEnumerable<DeleteConfigResponse>>>> DeleteConfig(DeleteConfigRequest request, CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request<DeleteConfigRequest>
        {
            HttpMethod = HttpMethod.Delete,
            Uri = "config/delete",
            Content = request
        };

        return await _httpRequestService.SendRequestAsync<DeleteConfigRequest, Result<IEnumerable<DeleteConfigResponse>>>(requestMessage, cancellationToken);
    }
    #endregion

    #region Health
    public async Task<HttpResult<HealthCheckResponse>> Health(CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request
        {
            HttpMethod = HttpMethod.Get,
            Uri = "health",
        };

        return await _httpRequestService.SendRequestAsync<HealthCheckResponse>(requestMessage, cancellationToken);
    }
    #endregion

    #region Logs
    public async Task<HttpResult<Result<IEnumerable<object>>>> LogsList(LogsListRequest request, CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request<LogsListRequest>
        {
            HttpMethod = HttpMethod.Post,
            Uri = "logs",
            Content = request
        };

        return await _httpRequestService.SendRequestAsync<LogsListRequest, Result<IEnumerable<object>>>(requestMessage, cancellationToken);
    }
    #endregion

    #region Connectors
    public async Task<HttpResult<Result<ConnectorDetailsResponse>>> ConnectorDetails(ConnectorDetailsRequest request, CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request<ConnectorDetailsRequest>
        {
            HttpMethod = HttpMethod.Post,
            Uri = "connectors/details",
            Content = request
        };

        return await _httpRequestService.SendRequestAsync<ConnectorDetailsRequest, Result<ConnectorDetailsResponse>>(requestMessage, cancellationToken);
    }

    public async Task<HttpResult<Result<IEnumerable<object>>>> ConnectorsList(ConnectorsListRequest request, CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request<ConnectorsListRequest>
        {
            HttpMethod = HttpMethod.Post,
            Uri = "connectors",
            Content = request
        };

        return await _httpRequestService.SendRequestAsync<ConnectorsListRequest, Result<IEnumerable<object>>>(requestMessage, cancellationToken);
    }
    #endregion

    #region InvokeMethod
    public async Task<HttpResult<Result<TResponse>>> InvokeMethod<TRequest, TResponse>(string methodName, TRequest data, 
        CancellationToken cancellationToken = default)
    {
        return await InvokeMethod<TRequest, TResponse>(HttpMethod.Post, methodName, data, cancellationToken);
    }

    public async Task<HttpResult<Result<TResponse>>> InvokeMethod<TRequest, TResponse>(HttpMethod httpMethod, string methodName, 
        TRequest data, CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request<TRequest>
        {
            HttpMethod = httpMethod,
            Uri = methodName,
            Content = data
        };
        
        return await InvokeMethod<TRequest, TResponse>(requestMessage, cancellationToken);
    }

    public async Task<HttpResult<Result<TResponse>>> InvokeMethod<TRequest, TResponse>(Request<TRequest> request, 
        CancellationToken cancellationToken = default)
    {
        return await _httpRequestService.SendRequestAsync<TRequest, Result<TResponse>>(request, cancellationToken);
    }

    public async Task<HttpResult<byte[]>> InvokeMethod<TRequest>(string methodName, TRequest data,
        CancellationToken cancellationToken = default)
    {
        return await InvokeMethod<TRequest>(HttpMethod.Post, methodName, data, cancellationToken);
    }

    public async Task<HttpResult<byte[]>> InvokeMethod<TRequest>(HttpMethod httpMethod, string methodName, TRequest data, 
        CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request<TRequest>
        {
            HttpMethod = httpMethod,
            Uri = methodName,
            Content = data
        };

        return await InvokeMethod<TRequest>(requestMessage, cancellationToken);
    }

    public async Task<HttpResult<byte[]>> InvokeMethod<TRequest>(Request<TRequest> request, CancellationToken cancellationToken = default)
    {
        var result = await _httpRequestService.SendRequestAsync(request, cancellationToken);
        return result;
    }
    #endregion

    #region Version
    public async Task<HttpResult<Result<VersionResponse>>> Version(CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request
        {
            HttpMethod = HttpMethod.Get,
            Uri = "version"
        };

        return await _httpRequestService.SendRequestAsync<Result<VersionResponse>>(requestMessage, cancellationToken);
    }
    #endregion

    public void Dispose()
    {
        _httpRequestService.Dispose();
    }
}