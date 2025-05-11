using FlowSynx.Client.Messages.Requests.Plugins;
using FlowSynx.Client.Messages.Responses.Plugins;
using FlowSynx.Client.Messages.Responses;

namespace FlowSynx.Client.Services;

public interface IPluginsService
{
    Task<HttpResult<Result<IEnumerable<PluginsListResponse>>>> ListAsync(
       CancellationToken cancellationToken = default);

    Task<HttpResult<Result<Unit>>> InstallAsync(
        InstallPluginRequest request,
        CancellationToken cancellationToken = default);

    Task<HttpResult<Result<PluginDetailsResponse>>> DetailsAsync(
        PluginDetailsRequest request,
        CancellationToken cancellationToken = default);

    Task<HttpResult<Result<Unit>>> UpdateAsync(
        UpdatePluginRequest request,
        CancellationToken cancellationToken = default);

    Task<HttpResult<Result<Unit>>> UninstallAsync(
        UninstallPluginRequest request,
        CancellationToken cancellationToken = default);
}