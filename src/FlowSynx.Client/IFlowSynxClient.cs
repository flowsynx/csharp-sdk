using FlowSynx.Client.Services;

namespace FlowSynx.Client;

public interface IFlowSynxClient
{
    IAuditService Audits { get; }
    IPluginConfigService PluginConfig { get; }
    ILogsService Logs { get; }
    IPluginsService Plugins { get; }
    IWorkflowsService Workflows { get; }
    IHealthCheckService HealthCheck { get; }
    IVersionService Version { get; }
}