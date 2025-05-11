using FlowSynx.Client.Authentication;
using FlowSynx.Client.Services;

namespace FlowSynx.Client;

/// <summary>
/// Represents a client for interacting with the FlowSynx service, providing access to various services
/// related to authentication, audits, plugins, workflows, logs, health checks, and versioning.
/// </summary>
public interface IFlowSynxClient
{
    /// <summary>
    /// Sets the authentication strategy to be used by the client.
    /// </summary>
    /// <param name="strategy">The authentication strategy to set.</param>
    void SetAuthenticationStrategy(IAuthenticationStrategy strategy);

    /// <summary>
    /// Gets the audit service for tracking and managing audit logs.
    /// </summary>
    /// <value>The audit service.</value>
    IAuditService Audits { get; }

    /// <summary>
    /// Gets the plugin configuration service for managing plugin configurations.
    /// </summary>
    /// <value>The plugin configuration service.</value>
    IPluginConfigService PluginConfig { get; }

    /// <summary>
    /// Gets the logs service for interacting with logs related to the FlowSynx client.
    /// </summary>
    /// <value>The logs service.</value>
    ILogsService Logs { get; }

    /// <summary>
    /// Gets the plugins service for managing and interacting with plugins.
    /// </summary>
    /// <value>The plugins service.</value>
    IPluginsService Plugins { get; }

    /// <summary>
    /// Gets the workflows service for managing workflows and their executions.
    /// </summary>
    /// <value>The workflows service.</value>
    IWorkflowsService Workflows { get; }

    /// <summary>
    /// Gets the health check service for performing health checks on the client or services.
    /// </summary>
    /// <value>The health check service.</value>
    IHealthCheckService HealthCheck { get; }

    /// <summary>
    /// Gets the version service for retrieving version information about the FlowSynx client.
    /// </summary>
    /// <value>The version service.</value>
    IVersionService Version { get; }
}