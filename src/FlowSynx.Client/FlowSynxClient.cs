using FlowSynx.Client.Http;
using FlowSynx.Client.Services;
using FlowSynx.Client.Authentication;

namespace FlowSynx.Client;

public class FlowSynxClient : IFlowSynxClient
{
    private readonly IHttpRequestHandler _httpRequestHandler;

    public FlowSynxClient(
        IFlowSynxClientConnection connection,
        IAuthenticationStrategy authenticationStrategy,
        IFlowSynxServiceFactory serviceFactory)
    {
        _httpRequestHandler = serviceFactory.CreateHttpRequestHandler(connection.BaseAddress, authenticationStrategy);

        Audits = serviceFactory.CreateAuditService(_httpRequestHandler);
        PluginConfig = serviceFactory.CreatePluginConfigService(_httpRequestHandler);
        Logs = serviceFactory.CreateLogsService(_httpRequestHandler);
        Plugins = serviceFactory.CreatePluginsService(_httpRequestHandler);
        Workflows = serviceFactory.CreateWorkflowsService(_httpRequestHandler);
        HealthCheck = serviceFactory.CreateHealthCheckService(_httpRequestHandler);
        Version = serviceFactory.CreateVersionService(_httpRequestHandler);
    }

    public void SetAuthenticationStrategy(IAuthenticationStrategy strategy) =>
        _httpRequestHandler.SetAuthenticationStrategy(strategy);

    public IAuditService Audits { get; }
    public IPluginConfigService PluginConfig { get; }
    public ILogsService Logs { get; }
    public IPluginsService Plugins { get; }
    public IWorkflowsService Workflows { get; }
    public IHealthCheckService HealthCheck { get; }
    public IVersionService Version { get; }
}