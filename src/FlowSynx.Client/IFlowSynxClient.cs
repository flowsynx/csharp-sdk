using FlowSynx.Client.Requests.Config;
using FlowSynx.Client.Responses;
using FlowSynx.Client.Responses.Config;
using FlowSynx.Client.Responses.Health;
using FlowSynx.Client.Responses.Version;
using FlowSynx.Client.Requests.Logs;
using FlowSynx.Client.Requests;
using FlowSynx.Client.Responses.Connectors;
using FlowSynx.Client.Requests.Connectors;

namespace FlowSynx.Client;

public interface IFlowSynxClient : IDisposable
{
    void ChangeConnection(string baseAddress);

    #region Configuration
    Task<HttpResult<Result<AddConfigResponse>>> AddConfig(AddConfigRequest request, CancellationToken cancellationToken = default);
    Task<HttpResult<Result<ConfigDetailsResponse>>> ConfigDetails(ConfigDetailsRequest request, CancellationToken cancellationToken = default);
    Task<HttpResult<Result<IEnumerable<object>>>> ConfigList(ConfigListRequest request, CancellationToken cancellationToken = default);
    Task<HttpResult<Result<IEnumerable<DeleteConfigResponse>>>> DeleteConfig(DeleteConfigRequest request, CancellationToken cancellationToken = default);
    #endregion

    #region Health
    Task<HttpResult<HealthCheckResponse>> Health(CancellationToken cancellationToken = default);
    #endregion

    #region Logs

    Task<HttpResult<Result<IEnumerable<object>>>> LogsList(LogsListRequest request, CancellationToken cancellationToken = default);
    #endregion

    #region Connectors
    Task<HttpResult<Result<ConnectorDetailsResponse>>> ConnectorDetails(ConnectorDetailsRequest request, CancellationToken cancellationToken = default);
    Task<HttpResult<Result<IEnumerable<object>>>> ConnectorsList(ConnectorsListRequest request, CancellationToken cancellationToken = default);
    #endregion

    #region InvokeMethod

    public Task<HttpResult<Result<TResponse>>> InvokeMethod<TRequest, TResponse>(string methodName, TRequest data,
        CancellationToken cancellationToken = default);

    public Task<HttpResult<Result<TResponse>>> InvokeMethod<TRequest, TResponse>(HttpMethod httpMethod, string methodName,
        TRequest data, CancellationToken cancellationToken = default);

    public Task<HttpResult<Result<TResponse>>> InvokeMethod<TRequest, TResponse>(Request<TRequest> request,
        CancellationToken cancellationToken = default);

    public Task<HttpResult<Stream>> InvokeMethod<TRequest>(string methodName, TRequest data,
        CancellationToken cancellationToken = default);

    public Task<HttpResult<Stream>> InvokeMethod<TRequest>(HttpMethod httpMethod, string methodName, TRequest data,
        CancellationToken cancellationToken = default);

    public Task<HttpResult<Stream>> InvokeMethod<TRequest>(Request<TRequest> request,
        CancellationToken cancellationToken = default);
    #endregion

    #region Version
    Task<HttpResult<Result<VersionResponse>>> Version(CancellationToken cancellationToken = default);
    #endregion
}