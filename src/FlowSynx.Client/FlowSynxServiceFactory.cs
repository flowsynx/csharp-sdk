using FlowSynx.Client.Authentication;
using FlowSynx.Client.Http;
using FlowSynx.Client.Services;

namespace FlowSynx.Client;

/// <summary>
/// Factory class for creating instances of various FlowSynx services, such as HTTP request handlers, audit services, and workflow services.
/// </summary>
public class FlowSynxServiceFactory : IFlowSynxServiceFactory
{
    private readonly IHttpClientFactory _httpClientFactory;

    /// <summary>
    /// Initializes a new instance of the <see cref="FlowSynxServiceFactory"/> class.
    /// </summary>
    /// <param name="httpClientFactory">The HTTP client factory used to create HTTP clients for service communication.</param>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="httpClientFactory"/> is null.</exception>
    public FlowSynxServiceFactory(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
    }

    /// <summary>
    /// Creates an instance of <see cref="IHttpRequestHandler"/> configured with the specified base address and authentication strategy.
    /// </summary>
    /// <param name="baseAddress">The base address for HTTP requests.</param>
    /// <param name="authenticationStrategy">The authentication strategy used for HTTP requests.</param>
    /// <returns>An instance of <see cref="IHttpRequestHandler"/> configured with the provided parameters.</returns>
    public IHttpRequestHandler CreateHttpRequestHandler(string baseAddress, IAuthenticationStrategy authenticationStrategy)
    {
        var httpClient = _httpClientFactory.CreateClient();
        httpClient.BaseAddress = new Uri(baseAddress);
        return new HttpRequestHandler(httpClient, authenticationStrategy);
    }

    /// <summary>
    /// Creates an instance of <see cref="IAuditService"/> using the provided HTTP request handler.
    /// </summary>
    /// <param name="httpRequestHandler">The HTTP request handler used for making requests related to auditing.</param>
    /// <returns>An instance of <see cref="IAuditService"/>.</returns>
    public IAuditService CreateAuditService(IHttpRequestHandler httpRequestHandler)
    {
        return new AuditService(httpRequestHandler);
    }

    /// <summary>
    /// Creates an instance of <see cref="IPluginConfigService"/> using the provided HTTP request handler.
    /// </summary>
    /// <param name="httpRequestHandler">The HTTP request handler used for making requests related to plugin configuration.</param>
    /// <returns>An instance of <see cref="IPluginConfigService"/>.</returns>
    public IPluginConfigService CreatePluginConfigService(IHttpRequestHandler httpRequestHandler)
    {
        return new PluginConfigService(httpRequestHandler);
    }

    /// <summary>
    /// Creates an instance of <see cref="ILogsService"/> using the provided HTTP request handler.
    /// </summary>
    /// <param name="httpRequestHandler">The HTTP request handler used for making requests related to logs.</param>
    /// <returns>An instance of <see cref="ILogsService"/>.</returns>
    public ILogsService CreateLogsService(IHttpRequestHandler httpRequestHandler)
    {
        return new LogsService(httpRequestHandler);
    }

    /// <summary>
    /// Creates an instance of <see cref="IMetricsService"/> using the provided HTTP request handler.
    /// </summary>
    /// <param name="httpRequestHandler">The HTTP request handler used for making requests related to metrics.</param>
    /// <returns>An instance of <see cref="ILogsService"/>.</returns>
    public IMetricsService CreateMetricsService(IHttpRequestHandler httpRequestHandler)
    {
        return new MetricsService(httpRequestHandler);
    }

    /// <summary>
    /// Creates an instance of <see cref="IPluginsService"/> using the provided HTTP request handler.
    /// </summary>
    /// <param name="httpRequestHandler">The HTTP request handler used for making requests related to plugins.</param>
    /// <returns>An instance of <see cref="IPluginsService"/>.</returns>
    public IPluginsService CreatePluginsService(IHttpRequestHandler httpRequestHandler)
    {
        return new PluginsService(httpRequestHandler);
    }

    /// <summary>
    /// Creates an instance of <see cref="IWorkflowsService"/> using the provided HTTP request handler.
    /// </summary>
    /// <param name="httpRequestHandler">The HTTP request handler used for making requests related to workflows.</param>
    /// <returns>An instance of <see cref="IWorkflowsService"/>.</returns>
    public IWorkflowsService CreateWorkflowsService(IHttpRequestHandler httpRequestHandler)
    {
        return new WorkflowsService(httpRequestHandler);
    }

    /// <summary>
    /// Creates an instance of <see cref="IHealthCheckService"/> using the provided HTTP request handler.
    /// </summary>
    /// <param name="httpRequestHandler">The HTTP request handler used for making requests related to health checks.</param>
    /// <returns>An instance of <see cref="IHealthCheckService"/>.</returns>
    public IHealthCheckService CreateHealthCheckService(IHttpRequestHandler httpRequestHandler)
    {
        return new HealthCheckService(httpRequestHandler);
    }

    /// <summary>
    /// Creates an instance of <see cref="IVersionService"/> using the provided HTTP request handler.
    /// </summary>
    /// <param name="httpRequestHandler">The HTTP request handler used for making requests related to versioning.</param>
    /// <returns>An instance of <see cref="IVersionService"/>.</returns>
    public IVersionService CreateVersionService(IHttpRequestHandler httpRequestHandler)
    {
        return new VersionService(httpRequestHandler);
    }
}