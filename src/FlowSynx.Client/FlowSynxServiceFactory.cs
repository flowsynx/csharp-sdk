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

    public IHttpRequestService CreateHttpRequestService(string baseAddress, IAuthenticationStrategy authenticationStrategy)
    {
        var httpClient = _httpClientFactory.CreateClient();
        httpClient.BaseAddress = new Uri(baseAddress);
        return new HttpRequestService(httpClient, authenticationStrategy);
    }

    public IAuditService CreateAuditService(IHttpRequestService httpRequestService)
    {
        return new AuditService(httpRequestService);
    }

    public IPluginConfigService CreatePluginConfigService(IHttpRequestService httpRequestService)
    {
        return new PluginConfigService(httpRequestService);
    }

    public ILogsService CreateLogsService(IHttpRequestService httpRequestService)
    {
        return new LogsService(httpRequestService);
    }

    public IPluginsService CreatePluginsService(IHttpRequestService httpRequestService)
    {
        return new PluginsService(httpRequestService);
    }

    public IWorkflowsService CreateWorkflowsService(IHttpRequestService httpRequestService)
    {
        return new WorkflowsService(httpRequestService);
    }

    public IHealthCheckService CreateHealthCheckService(IHttpRequestService httpRequestService)
    {
        return new HealthCheckService(httpRequestService);
    }

    public IVersionService CreateVersionService(IHttpRequestService httpRequestService)
    {
        return new VersionService(httpRequestService);
    }
}