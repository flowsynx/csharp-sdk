using FlowSynx.Client.Authentication;
using FlowSynx.Client.Http;
using FlowSynx.Client.Services;

namespace FlowSynx.Client;

public interface IFlowSynxServiceFactory
{
    IHttpRequestHandler CreateHttpRequestHandler(string baseAddress, IAuthenticationStrategy authenticationStrategy);
    IAuditService CreateAuditService(IHttpRequestHandler httpRequestHandler);
    IPluginConfigService CreatePluginConfigService(IHttpRequestHandler httpRequestHandler);
    ILogsService CreateLogsService(IHttpRequestHandler httpRequestHandler);
    IPluginsService CreatePluginsService(IHttpRequestHandler httpRequestHandler);
    IWorkflowsService CreateWorkflowsService(IHttpRequestHandler httpRequestHandler);
    IHealthCheckService CreateHealthCheckService(IHttpRequestHandler httpRequestHandler);
    IVersionService CreateVersionService(IHttpRequestHandler httpRequestHandler);
}