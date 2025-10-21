using FlowSynx.Client.Http;
using FlowSynx.Client.Messages.Responses;
using FlowSynx.Client.Messages.Requests;
using FlowSynx.Client.Messages.Requests.Plugins;
using FlowSynx.Client.Messages.Responses.Plugins;

namespace FlowSynx.Client.Services;

public class PluginsService: IPluginsService
{
    private readonly IHttpRequestHandler _httpRequestHandler;

    public PluginsService(IHttpRequestHandler httpRequestHandler) => 
        _httpRequestHandler = httpRequestHandler;

    public async Task<HttpResult<PaginatedResult<PluginsListResponse>>> ListAsync(
        CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request
        {
            HttpMethod = HttpMethod.Get,
            Uri = "plugins"
        };

        return await _httpRequestHandler
            .SendRequestAsync<PaginatedResult<PluginsListResponse>>(requestMessage, cancellationToken);
    }

    public async Task<HttpResult<Result<Unit>>> InstallAsync(
        InstallPluginRequest request,
        CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request<InstallPluginRequest>
        {
            HttpMethod = HttpMethod.Post,
            Uri = "plugins",
            Content = request
        };

        return await _httpRequestHandler
            .SendRequestAsync<InstallPluginRequest, Result<Unit>>(requestMessage, cancellationToken);
    }

    public async Task<HttpResult<Result<PluginDetailsResponse>>> DetailsAsync(
        PluginDetailsRequest request,
        CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request
        {
            HttpMethod = HttpMethod.Get,
            Uri = $"plugins/{request.Id.ToString()}"
        };

        return await _httpRequestHandler
            .SendRequestAsync<Result<PluginDetailsResponse>>(requestMessage, cancellationToken);
    }

    public async Task<HttpResult<Result<Unit>>> UpdateAsync(
        UpdatePluginRequest request,
        CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request<UpdatePluginRequest>
        {
            HttpMethod = HttpMethod.Put,
            Uri = "plugins",
            Content = request
        };

        return await _httpRequestHandler
            .SendRequestAsync<UpdatePluginRequest, Result<Unit>>(requestMessage, cancellationToken);
    }

    public async Task<HttpResult<Result<Unit>>> UninstallAsync(
        UninstallPluginRequest request,
        CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request<UninstallPluginRequest>
        {
            HttpMethod = HttpMethod.Delete,
            Uri = "plugins",
            Content = request
        };

        return await _httpRequestHandler
            .SendRequestAsync<UninstallPluginRequest, Result<Unit>>(requestMessage, cancellationToken);
    }
}