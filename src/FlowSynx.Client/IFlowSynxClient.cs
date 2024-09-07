using FlowSynx.Client.Requests.Config;
using FlowSynx.Client.Requests.Plugins;
using FlowSynx.Client.Responses;
using FlowSynx.Client.Responses.Config;
using FlowSynx.Client.Responses.Health;
using FlowSynx.Client.Responses.Plugins;
using FlowSynx.Client.Responses.Version;
using FlowSynx.Client.Requests.Logs;
using FlowSynx.Client.Responses.Logs;
using FlowSynx.Client.Requests;

namespace FlowSynx.Client;

public interface IFlowSynxClient : IDisposable
{
    void ChangeConnection(string baseAddress);

    #region Configuration
    Task<Result<AddConfigResponse>> AddConfig(AddConfigRequest request, CancellationToken cancellationToken = default);
    Task<Result<ConfigDetailsResponse>> ConfigDetails(ConfigDetailsRequest request, CancellationToken cancellationToken = default);
    Task<Result<IEnumerable<ConfigListResponse>>> ConfigList(ConfigListRequest request, CancellationToken cancellationToken = default);
    Task<Result<IEnumerable<DeleteConfigResponse>>> DeleteConfig(DeleteConfigRequest request, CancellationToken cancellationToken = default);
    #endregion

    #region Health
    Task<HealthCheckResponse> Health(CancellationToken cancellationToken = default);
    #endregion

    #region MyRegion

    Task<Result<IEnumerable<LogsListResponse>>> LogsList(LogsListRequest request, CancellationToken cancellationToken = default);
    #endregion

    #region Plugins
    Task<Result<PluginDetailsResponse>> PluginDetails(PluginDetailsRequest request, CancellationToken cancellationToken = default);
    Task<Result<IEnumerable<PluginsListResponse>>> PluginsList(PluginsListRequest request, CancellationToken cancellationToken = default);
    #endregion

    #region InvokeMethod

    public Task<Result<TResponse>> InvokeMethod<TRequest, TResponse>(string methodName, TRequest data,
        CancellationToken cancellationToken = default);

    public Task<Result<TResponse>> InvokeMethod<TRequest, TResponse>(HttpMethod httpMethod, string methodName,
        TRequest data, CancellationToken cancellationToken = default);

    public Task<Result<TResponse>> InvokeMethod<TRequest, TResponse>(Request<TRequest> request,
        CancellationToken cancellationToken = default);

    public Task<HttpResult<Stream>> InvokeMethod<TRequest>(string methodName, TRequest data,
        CancellationToken cancellationToken = default);

    public Task<HttpResult<Stream>> InvokeMethod<TRequest>(HttpMethod httpMethod, string methodName, TRequest data,
        CancellationToken cancellationToken = default);

    public Task<HttpResult<Stream>> InvokeMethod<TRequest>(Request<TRequest> request,
        CancellationToken cancellationToken = default);
    #endregion

    #region Version
    Task<Result<VersionResponse>> Version(CancellationToken cancellationToken = default);
    #endregion
}