using FlowSynx.Client.Http;
using FlowSynx.Client.Services;
using FlowSynx.Client.Authentication;

namespace FlowSynx.Client;

/// <summary>
/// Represents a client for interacting with the FlowSynx API.
/// </summary>
public class FlowSynxClient : IFlowSynxClient
{
    private readonly IHttpRequestHandler _httpRequestHandler;

    /// <summary>
    /// Initializes a new instance of the <see cref="FlowSynxClient"/> class.
    /// </summary>
    /// <param name="connection">The connection settings used to configure the client's base address.</param>
    /// <param name="authenticationStrategy">The authentication strategy to be used for making API requests.</param>
    /// <param name="serviceFactory">A factory used to create the various services required for interacting with the FlowSynx API.</param>
    /// <remarks>
    /// The constructor initializes the client by setting up various services such as auditing, plugin configuration,
    /// logging, plugins management, workflows, health checks, and version management, each based on the provided
    /// <paramref name="httpRequestHandler"/>.
    /// </remarks>
    public FlowSynxClient(
        IFlowSynxClientConnection connection,
        IAuthenticationStrategy authenticationStrategy,
        IFlowSynxServiceFactory serviceFactory)
    {
        _httpRequestHandler = serviceFactory.CreateHttpRequestHandler(connection.BaseAddress, authenticationStrategy);

        Audits = serviceFactory.CreateAuditService(_httpRequestHandler);
        Logs = serviceFactory.CreateLogsService(_httpRequestHandler);
        Metrics = serviceFactory.CreateMetricsService(_httpRequestHandler);
        Plugins = serviceFactory.CreatePluginsService(_httpRequestHandler);
        Workflows = serviceFactory.CreateWorkflowsService(_httpRequestHandler);
        HealthCheck = serviceFactory.CreateHealthCheckService(_httpRequestHandler);
        Version = serviceFactory.CreateVersionService(_httpRequestHandler);
    }

    public void SetConnection(IFlowSynxClientConnection connection) =>
        _httpRequestHandler.SetHttpConnection(connection);

    public void SetAuthenticationStrategy(IAuthenticationStrategy strategy) =>
        _httpRequestHandler.SetAuthenticationStrategy(strategy);

    public IAuditService Audits { get; }
    public ILogsService Logs { get; }
    public IMetricsService Metrics { get; }
    public IPluginsService Plugins { get; }
    public IWorkflowsService Workflows { get; }
    public IHealthCheckService HealthCheck { get; }
    public IVersionService Version { get; }
}