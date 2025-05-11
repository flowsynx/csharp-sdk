using FlowSynx.Client.Messages.Responses.PluginConfig;
using FlowSynx.Client.Messages.Responses;
using FlowSynx.Client.Messages.Requests.PluginConfig;

namespace FlowSynx.Client.Services;

public interface IPluginConfigService
{
    Task<HttpResult<Result<IEnumerable<PluginConfigListResponse>>>> ListAsync(
        CancellationToken cancellationToken = default);

    Task<HttpResult<Result<AddPluginConfigResponse>>> AddAsync(
            AddPluginConfigRequest request,
            CancellationToken cancellationToken = default);

    Task<HttpResult<Result<PluginConfigDetailsResponse>>> DetailsAsync(
        PluginConfigDetailsRequest request,
        CancellationToken cancellationToken = default);

    Task<HttpResult<Result<Unit>>> UpdateAsync(
        UpdatePluginConfigRequest request,
        CancellationToken cancellationToken = default);

    Task<HttpResult<Result<Unit>>> DeleteAsync(
        DeletePluginConfigRequest request,
        CancellationToken cancellationToken = default);
}