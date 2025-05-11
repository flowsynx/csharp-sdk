using FlowSynx.Client.Authentication;
using FlowSynx.Client.Http;
using FlowSynx.Client.Services;

namespace FlowSynx.Client;

/// <summary>
/// Factory interface responsible for creating instances of various services used in the FlowSynx system.
/// </summary>
public interface IFlowSynxServiceFactory
{
    /// <summary>
    /// Creates an instance of an HTTP request handler for making requests to a specified base address with a given authentication strategy.
    /// </summary>
    /// <param name="baseAddress">The base address for the HTTP requests.</param>
    /// <param name="authenticationStrategy">The authentication strategy to be used in the requests.</param>
    /// <returns>An instance of <see cref="IHttpRequestHandler"/>.</returns>
    IHttpRequestHandler CreateHttpRequestHandler(string baseAddress, IAuthenticationStrategy authenticationStrategy);

    /// <summary>
    /// Creates an instance of the audit service to manage and record audit logs.
    /// </summary>
    /// <param name="httpRequestHandler">The HTTP request handler used to make API calls.</param>
    /// <returns>An instance of <see cref="IAuditService"/>.</returns>
    IAuditService CreateAuditService(IHttpRequestHandler httpRequestHandler);

    /// <summary>
    /// Creates an instance of the plugin configuration service to manage plugin configurations.
    /// </summary>
    /// <param name="httpRequestHandler">The HTTP request handler used to make API calls.</param>
    /// <returns>An instance of <see cref="IPluginConfigService"/>.</returns>
    IPluginConfigService CreatePluginConfigService(IHttpRequestHandler httpRequestHandler);

    /// <summary>
    /// Creates an instance of the logs service to manage and retrieve logs.
    /// </summary>
    /// <param name="httpRequestHandler">The HTTP request handler used to make API calls.</param>
    /// <returns>An instance of <see cref="ILogsService"/>.</returns>
    ILogsService CreateLogsService(IHttpRequestHandler httpRequestHandler);

    /// <summary>
    /// Creates an instance of the plugins service to manage and interact with plugins.
    /// </summary>
    /// <param name="httpRequestHandler">The HTTP request handler used to make API calls.</param>
    /// <returns>An instance of <see cref="IPluginsService"/>.</returns>
    IPluginsService CreatePluginsService(IHttpRequestHandler httpRequestHandler);

    /// <summary>
    /// Creates an instance of the workflows service to manage and execute workflows.
    /// </summary>
    /// <param name="httpRequestHandler">The HTTP request handler used to make API calls.</param>
    /// <returns>An instance of <see cref="IWorkflowsService"/>.</returns>
    IWorkflowsService CreateWorkflowsService(IHttpRequestHandler httpRequestHandler);

    /// <summary>
    /// Creates an instance of the health check service to monitor the health of the system.
    /// </summary>
    /// <param name="httpRequestHandler">The HTTP request handler used to make API calls.</param>
    /// <returns>An instance of <see cref="IHealthCheckService"/>.</returns>
    IHealthCheckService CreateHealthCheckService(IHttpRequestHandler httpRequestHandler);

    /// <summary>
    /// Creates an instance of the version service to manage and retrieve version information.
    /// </summary>
    /// <param name="httpRequestHandler">The HTTP request handler used to make API calls.</param>
    /// <returns>An instance of <see cref="IVersionService"/>.</returns>
    IVersionService CreateVersionService(IHttpRequestHandler httpRequestHandler);
}