using FlowSynx.Client.Http;
using FlowSynx.Client.Services;
using FlowSynx.Client.Authentication;

namespace FlowSynx.Client;

public class FlowSynxClient : IFlowSynxClient
{
    private readonly IHttpRequestService _httpRequestService;

    public FlowSynxClient(
        IFlowSynxClientConnection connection,
        IAuthenticationStrategy authenticationStrategy,
        IFlowSynxServiceFactory serviceFactory)
    {
        _httpRequestService = serviceFactory.CreateHttpRequestService(connection.BaseAddress, authenticationStrategy);

        Audits = serviceFactory.CreateAuditService(_httpRequestService);
        PluginConfig = serviceFactory.CreatePluginConfigService(_httpRequestService);
        Logs = serviceFactory.CreateLogsService(_httpRequestService);
        Plugins = serviceFactory.CreatePluginsService(_httpRequestService);
        Workflows = serviceFactory.CreateWorkflowsService(_httpRequestService);
        HealthCheck = serviceFactory.CreateHealthCheckService(_httpRequestService);
        Version = serviceFactory.CreateVersionService(_httpRequestService);
    }

    public IAuditService Audits { get; }
    public IPluginConfigService PluginConfig { get; }
    public ILogsService Logs { get; }
    public IPluginsService Plugins { get; }
    public IWorkflowsService Workflows { get; }
    public IHealthCheckService HealthCheck { get; }
    public IVersionService Version { get; }
}