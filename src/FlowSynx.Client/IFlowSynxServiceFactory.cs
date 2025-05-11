using FlowSynx.Client.Authentication;
using FlowSynx.Client.Http;
using FlowSynx.Client.Services;

namespace FlowSynx.Client;

public interface IFlowSynxServiceFactory
{
    IHttpRequestService CreateHttpRequestService(string baseAddress, IAuthenticationStrategy authenticationStrategy);
    IAuditService CreateAuditService(IHttpRequestService httpRequestService);
    IPluginConfigService CreatePluginConfigService(IHttpRequestService httpRequestService);
    ILogsService CreateLogsService(IHttpRequestService httpRequestService);
    IPluginsService CreatePluginsService(IHttpRequestService httpRequestService);
    IWorkflowsService CreateWorkflowsService(IHttpRequestService httpRequestService);
    IHealthCheckService CreateHealthCheckService(IHttpRequestService httpRequestService);
    IVersionService CreateVersionService(IHttpRequestService httpRequestService);
}