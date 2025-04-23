using FlowSynx.Client.Responses;
using FlowSynx.Client.Responses.Health;
using FlowSynx.Client.Responses.Version;
using FlowSynx.Client.Requests.Logs;
using FlowSynx.Client.Responses.PluginConfig;
using FlowSynx.Client.Requests.PluginConfig;
using FlowSynx.Client.Responses.Plugins;
using FlowSynx.Client.Requests.Plugins;
using FlowSynx.Client.Responses.Logs;
using FlowSynx.Client.Requests.Workflows;
using FlowSynx.Client.Responses.Workflows;

namespace FlowSynx.Client;

public interface IFlowSynxClient : IDisposable
{
    void ChangeConnection(string baseAddress);

    #region Authentication
    void UseBasicAuth(string username, string password);
    void UseBearerToken(string token);
    void ClearAuthentication();
    #endregion

    #region Plugin Configuration
    Task<HttpResult<Result<AddPluginConfigResponse>>> AddPluginConfig(AddPluginConfigRequest request, 
        CancellationToken cancellationToken = default);

    Task<HttpResult<Result<Unit>>> DeletePluginConfig(DeletePluginConfigRequest request, 
        CancellationToken cancellationToken = default);

    Task<HttpResult<Result<Unit>>> UpdatePluginConfig(UpdatePluginConfigRequest request, 
        CancellationToken cancellationToken = default);

    Task<HttpResult<Result<PluginConfigDetailsResponse>>> PluginConfigDetails(PluginConfigDetailsRequest request,
        CancellationToken cancellationToken = default);

    Task<HttpResult<Result<IEnumerable<PluginConfigListResponse>>>> PluginConfigList(
        CancellationToken cancellationToken = default);
    #endregion

    #region Health
    Task<HttpResult<HealthCheckResponse>> Health(CancellationToken cancellationToken = default);
    #endregion

    #region Logs

    Task<HttpResult<Result<IEnumerable<LogsListResponse>>>> LogsList(LogsListRequest request, 
        CancellationToken cancellationToken = default);
    #endregion

    #region Plugins
    Task<HttpResult<Result<Unit>>> InstallPlugin(InstallPluginRequest request, 
        CancellationToken cancellationToken = default);

    Task<HttpResult<Result<Unit>>> UninstallPlugin(UninstallPluginRequest request,
        CancellationToken cancellationToken = default);

    Task<HttpResult<Result<Unit>>> UpdatePlugin(UpdatePluginRequest request,
        CancellationToken cancellationToken = default);

    Task<HttpResult<Result<PluginDetailsResponse>>> PluginDetails(PluginDetailsRequest request, 
        CancellationToken cancellationToken = default);

    Task<HttpResult<Result<IEnumerable<PluginsListResponse>>>> PluginsList(
        CancellationToken cancellationToken = default);
    #endregion

    #region Version
    Task<HttpResult<Result<VersionResponse>>> Version(CancellationToken cancellationToken = default);
    #endregion

    #region Workflows
    Task<HttpResult<Result<AddWorkflowResponse>>> AddWorkflow(AddWorkflowRequest request, 
        CancellationToken cancellationToken = default);

    Task<HttpResult<Result<Unit>>> DeleteWorkflow(DeleteWorkflowRequest request,
        CancellationToken cancellationToken = default);

    Task<HttpResult<Result<Unit>>> UpdateWorkflow(UpdateWorkflowRequest request,
        CancellationToken cancellationToken = default);

    Task<HttpResult<Result<WorkflowDetailsResponse>>> WorkflowDetails(WorkflowDetailsRequest request,
        CancellationToken cancellationToken = default);

    Task<HttpResult<Result<IEnumerable<WorkflowListResponse>>>> WorkflowsList(
        CancellationToken cancellationToken = default);

    Task<HttpResult<Result<Unit>>> ExecuteWorkflow(ExecuteWorkflowRequest request,
        CancellationToken cancellationToken = default);
    #endregion
}