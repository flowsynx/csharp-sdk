using FlowSynx.Client.Exceptions;
using FlowSynx.Client.Http;
using FlowSynx.Client.Requests;
using FlowSynx.Client.Requests.Logs;
using FlowSynx.Client.Responses;
using FlowSynx.Client.Responses.Health;
using FlowSynx.Client.Responses.Version;
using FlowSynx.Client.Requests.PluginConfig;
using FlowSynx.Client.Responses.PluginConfig;
using FlowSynx.Client.Requests.Plugins;
using FlowSynx.Client.Responses.Plugins;
using FlowSynx.Client.Responses.Logs;
using FlowSynx.Client.Requests.Workflows;
using FlowSynx.Client.Responses.Workflows;

namespace FlowSynx.Client;

public class FlowSynxClient : IFlowSynxClient
{
    private IHttpRequestService _httpRequestService;
    public FlowSynxClientConnection Connection { get; }

    public FlowSynxClient(FlowSynxClientConnection clientConnection)
    {
        var baseAddress = clientConnection.BaseAddress;
        if (string.IsNullOrEmpty(baseAddress))
            baseAddress = FlowSynxEnvironments.GetDefaultHttpEndpoint();

        CheckAddress(baseAddress);
        _httpRequestService = HttpRequestService.Create(baseAddress);
        Connection = clientConnection;
    }

    public void ChangeConnection(string baseAddress)
    {
        CheckAddress(baseAddress);
        _httpRequestService = HttpRequestService.Create(baseAddress);
    }

    #region Authentication
    public void UseBasicAuth(string username, string password)
    {
        _httpRequestService.UseBasicAuth(username, password);
    }

    public void UseBearerToken(string token)
    {
        _httpRequestService.UseBearerToken(token);
    }

    public void ClearAuthentication()
    {
        _httpRequestService.ClearAuthentication();
    }

    #endregion

    #region private methods
    private void CheckAddress(string baseAddress)
    {
        if (!IsUrlValid(baseAddress))
            throw new FlowSynxClientException($"Entered address {baseAddress} is not valid. Please check it and try again!");
    }

    private bool IsUrlValid(string url) => Uri.TryCreate(url, UriKind.Absolute, out var uriResult)
                                           && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
    #endregion

    #region Plugin Configuration
    public async Task<HttpResult<Result<AddPluginConfigResponse>>> AddPluginConfig(
        AddPluginConfigRequest request,
        CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request<AddPluginConfigRequest>
        {
            HttpMethod = HttpMethod.Post,
            Uri = "config/add",
            Content = request
        };

        return await _httpRequestService
            .SendRequestAsync<AddPluginConfigRequest, Result<AddPluginConfigResponse>>(requestMessage, cancellationToken);
    }

    public async Task<HttpResult<Result<Unit>>> DeletePluginConfig(
        DeletePluginConfigRequest request, 
        CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request
        {
            HttpMethod = HttpMethod.Delete,
            Uri = $"config/delete/{request.Id.ToString()}"
        };

        return await _httpRequestService
            .SendRequestAsync<Result<Unit>>(requestMessage, cancellationToken);
    }

    public async Task<HttpResult<Result<Unit>>> UpdatePluginConfig(
        UpdatePluginConfigRequest request,
        CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request<UpdatePluginConfigRequest>
        {
            HttpMethod = HttpMethod.Post,
            Uri = $"config/update/{request.Id.ToString()}",
            Content = request
        };

        return await _httpRequestService
            .SendRequestAsync<UpdatePluginConfigRequest, Result<Unit>>(requestMessage, cancellationToken);
    }

    public async Task<HttpResult<Result<PluginConfigDetailsResponse>>> PluginConfigDetails(
        PluginConfigDetailsRequest request,
        CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request
        {
            HttpMethod = HttpMethod.Get,
            Uri = $"config/details/{request.Id.ToString()}"
        };

        return await _httpRequestService
            .SendRequestAsync<Result<PluginConfigDetailsResponse>>(requestMessage, cancellationToken);
    }

    public async Task<HttpResult<Result<IEnumerable<PluginConfigListResponse>>>> PluginConfigList(
        CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request
        {
            HttpMethod = HttpMethod.Get,
            Uri = "config"
        };

        return await _httpRequestService.SendRequestAsync<Result<IEnumerable<PluginConfigListResponse>>>(requestMessage, cancellationToken);
    }
    #endregion

    #region Health
    public async Task<HttpResult<HealthCheckResponse>> Health(
        CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request
        {
            HttpMethod = HttpMethod.Get,
            Uri = "health",
        };

        return await _httpRequestService
            .SendRequestAsync<HealthCheckResponse>(requestMessage, cancellationToken);
    }
    #endregion

    #region Logs
    public async Task<HttpResult<Result<IEnumerable<LogsListResponse>>>> LogsList(
        LogsListRequest request, 
        CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request<LogsListRequest>
        {
            HttpMethod = HttpMethod.Post,
            Uri = "logs",
            Content = request
        };

        return await _httpRequestService
            .SendRequestAsync<LogsListRequest, Result<IEnumerable<LogsListResponse>>>(requestMessage, cancellationToken);
    }
    #endregion

    #region Plugins
    public async Task<HttpResult<Result<Unit>>> AddPlugin(
        AddPluginRequest request, 
        CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request<AddPluginRequest>
        {
            HttpMethod = HttpMethod.Post,
            Uri = $"plugins/add",
            Content = request
        };

        return await _httpRequestService
            .SendRequestAsync<AddPluginRequest, Result<Unit>>(requestMessage, cancellationToken);
    }

    public async Task<HttpResult<Result<Unit>>> DeletePlugin(
        DeletePluginRequest request,
        CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request<DeletePluginRequest>
        {
            HttpMethod = HttpMethod.Delete,
            Uri = $"plugins/delete",
            Content = request
        };

        return await _httpRequestService
            .SendRequestAsync<DeletePluginRequest, Result<Unit>>(requestMessage, cancellationToken);
    }

    public async Task<HttpResult<Result<Unit>>> UpdatePlugin(
        UpdatePluginRequest request,
        CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request<UpdatePluginRequest>
        {
            HttpMethod = HttpMethod.Post,
            Uri = $"plugins/update",
            Content = request
        };

        return await _httpRequestService
            .SendRequestAsync<UpdatePluginRequest, Result<Unit>>(requestMessage, cancellationToken);
    }

    public async Task<HttpResult<Result<PluginDetailsResponse>>> PluginDetails(
        PluginDetailsRequest request,
        CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request
        {
            HttpMethod = HttpMethod.Get,
            Uri = $"plugins/details/{request.Id.ToString()}"
        };

        return await _httpRequestService
            .SendRequestAsync<Result<PluginDetailsResponse>>(requestMessage, cancellationToken);
    }

    public async Task<HttpResult<Result<IEnumerable<PluginsListResponse>>>> PluginsList(
        CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request
        {
            HttpMethod = HttpMethod.Get,
            Uri = "plugins"
        };

        return await _httpRequestService
            .SendRequestAsync<Result<IEnumerable<PluginsListResponse>>>(requestMessage, cancellationToken);
    }
    #endregion

    #region Version
    public async Task<HttpResult<Result<VersionResponse>>> Version(
        CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request
        {
            HttpMethod = HttpMethod.Get,
            Uri = "version"
        };

        return await _httpRequestService
            .SendRequestAsync<Result<VersionResponse>>(requestMessage, cancellationToken);
    }
    #endregion

    #region Workflows
    public async Task<HttpResult<Result<AddWorkflowResponse>>> AddWorkflow(
        AddWorkflowRequest request,
        CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request<AddWorkflowRequest>
        {
            HttpMethod = HttpMethod.Post,
            Uri = $"workflows/add",
            Content = request
        };

        return await _httpRequestService
            .SendRequestAsync<AddWorkflowRequest, Result<AddWorkflowResponse>>(requestMessage, cancellationToken);
    }

    public async Task<HttpResult<Result<Unit>>> DeleteWorkflow(
        DeleteWorkflowRequest request,
        CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request
        {
            HttpMethod = HttpMethod.Delete,
            Uri = $"workflows/delete/{request.Id.ToString()}"
        };

        return await _httpRequestService
            .SendRequestAsync<Result<Unit>>(requestMessage, cancellationToken);
    }

    public async Task<HttpResult<Result<Unit>>> UpdateWorkflow(
        UpdateWorkflowRequest request,
        CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request<string>
        {
            HttpMethod = HttpMethod.Post,
            Uri = $"workflows/update/{request.Id.ToString()}",
            Content = request.Definition
        };

        return await _httpRequestService
            .SendRequestAsync<string, Result<Unit>>(requestMessage, cancellationToken);
    }

    public async Task<HttpResult<Result<WorkflowDetailsResponse>>> WorkflowDetails(
        WorkflowDetailsRequest request,
        CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request
        {
            HttpMethod = HttpMethod.Get,
            Uri = $"workflows/details/{request.Id.ToString()}"
        };

        return await _httpRequestService
            .SendRequestAsync<Result<WorkflowDetailsResponse>>(requestMessage, cancellationToken);
    }

    public async Task<HttpResult<Result<IEnumerable<WorkflowListResponse>>>> WorkflowsList(
        CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request
        {
            HttpMethod = HttpMethod.Get,
            Uri = "workflows"
        };

        return await _httpRequestService
            .SendRequestAsync<Result<IEnumerable<WorkflowListResponse>>>(requestMessage, cancellationToken);
    }

    public async Task<HttpResult<Result<Unit>>> ExecuteWorkflow(
        ExecuteWorkflowRequest request,
        CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request
        {
            HttpMethod = HttpMethod.Get,
            Uri = $"workflows/execute/{request.Id}"
        };

        return await _httpRequestService
            .SendRequestAsync<Result<Unit>>(requestMessage, cancellationToken);
    }
    #endregion

    public void Dispose()
    {
        _httpRequestService.Dispose();
    }
}