using FlowSynx.Client.Http;
using FlowSynx.Client.Messages.Responses;
using FlowSynx.Client.Messages.Requests;
using FlowSynx.Client.Messages.Requests.PluginConfig;
using FlowSynx.Client.Messages.Responses.PluginConfig;

namespace FlowSynx.Client.Services;

public class PluginConfigService: IPluginConfigService
{
    private readonly IHttpRequestService _httpRequestService;

    public PluginConfigService(IHttpRequestService httpRequestService) => 
        _httpRequestService = httpRequestService;

    public async Task<HttpResult<Result<IEnumerable<PluginConfigListResponse>>>> ListAsync(
        CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request
        {
            HttpMethod = HttpMethod.Get,
            Uri = "config"
        };

        return await _httpRequestService.SendRequestAsync<Result<IEnumerable<PluginConfigListResponse>>>(requestMessage, cancellationToken);
    }

    public async Task<HttpResult<Result<AddPluginConfigResponse>>> AddAsync(
            AddPluginConfigRequest request,
            CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request<AddPluginConfigRequest>
        {
            HttpMethod = HttpMethod.Post,
            Uri = "config",
            Content = request
        };

        return await _httpRequestService
            .SendRequestAsync<AddPluginConfigRequest, Result<AddPluginConfigResponse>>(requestMessage, cancellationToken);
    }

    public async Task<HttpResult<Result<PluginConfigDetailsResponse>>> DetailsAsync(
        PluginConfigDetailsRequest request,
        CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request
        {
            HttpMethod = HttpMethod.Get,
            Uri = $"config/{request.Id.ToString()}"
        };

        return await _httpRequestService
            .SendRequestAsync<Result<PluginConfigDetailsResponse>>(requestMessage, cancellationToken);
    }

    public async Task<HttpResult<Result<Unit>>> UpdateAsync(
        UpdatePluginConfigRequest request,
        CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request<UpdatePluginConfigRequest>
        {
            HttpMethod = HttpMethod.Put,
            Uri = $"config/{request.Id.ToString()}",
            Content = request
        };

        return await _httpRequestService
            .SendRequestAsync<UpdatePluginConfigRequest, Result<Unit>>(requestMessage, cancellationToken);
    }

    public async Task<HttpResult<Result<Unit>>> DeleteAsync(
        DeletePluginConfigRequest request,
        CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request
        {
            HttpMethod = HttpMethod.Delete,
            Uri = $"config/{request.Id.ToString()}"
        };

        return await _httpRequestService
            .SendRequestAsync<Result<Unit>>(requestMessage, cancellationToken);
    }
}