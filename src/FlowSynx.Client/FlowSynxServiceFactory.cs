using FlowSynx.Client.Authentication;
using FlowSynx.Client.Http;
using FlowSynx.Client.Services;

namespace FlowSynx.Client;

public class FlowSynxServiceFactory : IFlowSynxServiceFactory
{
    private readonly IHttpClientFactory _httpClientFactory;

    public FlowSynxServiceFactory(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
    }

    public IHttpRequestHandler CreateHttpRequestHandler(string baseAddress, IAuthenticationStrategy authenticationStrategy)
    {
        var httpClient = _httpClientFactory.CreateClient();
        httpClient.BaseAddress = new Uri(baseAddress);
        return new HttpRequestHandler(httpClient, authenticationStrategy);
    }

    public IAuditService CreateAuditService(IHttpRequestHandler httpRequestHandler)
    {
        return new AuditService(httpRequestHandler);
    }

    public IPluginConfigService CreatePluginConfigService(IHttpRequestHandler httpRequestHandler)
    {
        return new PluginConfigService(httpRequestHandler);
    }

    public ILogsService CreateLogsService(IHttpRequestHandler httpRequestHandler)
    {
        return new LogsService(httpRequestHandler);
    }

    public IPluginsService CreatePluginsService(IHttpRequestHandler httpRequestHandler)
    {
        return new PluginsService(httpRequestHandler);
    }

    public IWorkflowsService CreateWorkflowsService(IHttpRequestHandler httpRequestHandler)
    {
        return new WorkflowsService(httpRequestHandler);
    }

    public IHealthCheckService CreateHealthCheckService(IHttpRequestHandler httpRequestHandler)
    {
        return new HealthCheckService(httpRequestHandler);
    }

    public IVersionService CreateVersionService(IHttpRequestHandler httpRequestHandler)
    {
        return new VersionService(httpRequestHandler);
    }
}