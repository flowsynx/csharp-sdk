using FlowSynx.Client.Http;
using FlowSynx.Client.Requests;
using FlowSynx.Client.Requests.Config;
using FlowSynx.Client.Requests.Health;
using FlowSynx.Client.Requests.Plugins;
using FlowSynx.Client.Requests.Storage;
using FlowSynx.Client.Responses;
using FlowSynx.Client.Responses.Config;
using FlowSynx.Client.Responses.Health;
using FlowSynx.Client.Responses.Plugins;
using FlowSynx.Client.Responses.Storage;
using FlowSynx.Client.Responses.Version;

namespace FlowSynx.Client;

public class FlowSynxClient : IFlowSynxClient
{
    private readonly IHttpRequestService _httpRequestService;

    public FlowSynxClient()
    {
        _httpRequestService = HttpRequestService.Create();
    }

    #region Configuration
    public async Task<Result<AddConfigResponse>?> AddConfig(AddConfigRequest request, CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request<AddConfigRequest>
        {
            HttpMethod = HttpMethod.Post,
            Uri = "config/add",
            Content = request
        };

        return await _httpRequestService.SendRequestAsync<AddConfigRequest, Result<AddConfigResponse>>(requestMessage, cancellationToken);
    }

    public async Task<Result<ConfigDetailsResponse>?> ConfigDetails(ConfigDetailsRequest request, CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request
        {
            HttpMethod = HttpMethod.Get,
            Uri = $"config/details/{request.Name}"
        };

        return await _httpRequestService.SendRequestAsync<Result<ConfigDetailsResponse>>(requestMessage, cancellationToken);
    }

    public async Task<Result<IEnumerable<ConfigListResponse>>?> ConfigList(ConfigListRequest request, CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request<ConfigListRequest>
        {
            HttpMethod = HttpMethod.Post,
            Uri = "config",
            Content = request
        };

        return await _httpRequestService.SendRequestAsync<ConfigListRequest, Result<IEnumerable<ConfigListResponse>>>(requestMessage, cancellationToken);
    }

    public async Task<Result<DeleteConfigResponse>?> DeleteConfig(DeleteConfigRequest request, CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request<DeleteConfigRequest>
        {
            HttpMethod = HttpMethod.Delete,
            Uri = "config/delete",
            Content = request
        };

        return await _httpRequestService.SendRequestAsync<DeleteConfigRequest, Result<DeleteConfigResponse>>(requestMessage, cancellationToken);
    }
    #endregion

    #region Health
    public async Task<Result<HealthCheckResponse>?> Health(HealthCheckRequest request, CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request<HealthCheckRequest>
        {
            HttpMethod = HttpMethod.Get,
            Uri = "health",
            Content = request
        };

        return await _httpRequestService.SendRequestAsync<HealthCheckRequest, Result<HealthCheckResponse>>(requestMessage, cancellationToken);
    }
    #endregion

    #region Plugins

    public async Task<Result<PluginDetailsResponse>?> PluginDetails(PluginDetailsRequest request, CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request
        {
            HttpMethod = HttpMethod.Get,
            Uri = $"plugins/details/{request.Id}"
        };

        return await _httpRequestService.SendRequestAsync<Result<PluginDetailsResponse>>(requestMessage, cancellationToken);
    }

    public async Task<Result<IEnumerable<PluginsListResponse>>?> PluginsList(PluginsListRequest request, CancellationToken cancellationToken = default)
    {
        var uri = string.IsNullOrEmpty(request.Type) ? "plugins" : $"plugins/{request.Type}";
        var requestMessage = new Request<PluginsListRequest>
        {
            HttpMethod = HttpMethod.Get,
            Uri = uri,
            Content = request
        };

        return await _httpRequestService.SendRequestAsync<PluginsListRequest, Result<IEnumerable<PluginsListResponse>>>(requestMessage, cancellationToken);
    }
    #endregion

    #region Storage
    public async Task<Result<AboutResponse>?> About(AboutRequest request, CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request<AboutRequest>
        {
            HttpMethod = HttpMethod.Post,
            Uri = "storage/about",
            Content = request
        };

        return await _httpRequestService.SendRequestAsync<AboutRequest, Result<AboutResponse>>(requestMessage, cancellationToken);
    }

    public async Task<Result<CopyResponse>?> Copy(CopyRequest request, CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request<CopyRequest>
        {
            HttpMethod = HttpMethod.Post,
            Uri = "storage/copy",
            Content = request
        };

        return await _httpRequestService.SendRequestAsync<CopyRequest, Result<CopyResponse>>(requestMessage, cancellationToken);
    }

    public async Task<Result<DeleteFileResponse>?> DeleteFile(DeleteFileRequest request, CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request<DeleteFileRequest>
        {
            HttpMethod = HttpMethod.Delete,
            Uri = "storage/deletefile",
            Content = request
        };

        return await _httpRequestService.SendRequestAsync<DeleteFileRequest, Result<DeleteFileResponse>>(requestMessage, cancellationToken);
    }

    public async Task<Result<DeleteResponse>?> Delete(DeleteRequest request, CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request<DeleteRequest>
        {
            HttpMethod = HttpMethod.Delete,
            Uri = "storage/delete",
            Content = request
        };

        return await _httpRequestService.SendRequestAsync<DeleteRequest, Result<DeleteResponse>>(requestMessage, cancellationToken);
    }

    public async Task<Result<IEnumerable<ListResponse>>?> List(ListRequest request, CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request<ListRequest>
        {
            HttpMethod = HttpMethod.Post,
            Uri = "storage/list",
            Content = request
        };

        return await _httpRequestService.SendRequestAsync<ListRequest, Result<IEnumerable<ListResponse>>>(requestMessage, cancellationToken);
    }

    public async Task<Result<MakeDirectoryResponse>?> MakeDirectory(MakeDirectoryRequest request, CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request<MakeDirectoryRequest>
        {
            HttpMethod = HttpMethod.Post,
            Uri = "storage/mkdir",
            Content = request
        };

        return await _httpRequestService.SendRequestAsync<MakeDirectoryRequest, Result<MakeDirectoryResponse>>(requestMessage, cancellationToken);
    }

    public async Task<Result<MoveResponse>?> Move(MoveRequest request, CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request<MoveRequest>
        {
            HttpMethod = HttpMethod.Post,
            Uri = "storage/move",
            Content = request
        };

        return await _httpRequestService.SendRequestAsync<MoveRequest, Result<MoveResponse>>(requestMessage, cancellationToken);
    }

    public async Task<Result<PurgeDirectoryResponse>?> PurgeDirectory(PurgeDirectoryRequest request, CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request<PurgeDirectoryRequest>
        {
            HttpMethod = HttpMethod.Post,
            Uri = "storage/purge",
            Content = request
        };

        return await _httpRequestService.SendRequestAsync<PurgeDirectoryRequest, Result<PurgeDirectoryResponse>>(requestMessage, cancellationToken);
    }

    public async Task<Stream> Read(ReadRequest request, CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request<ReadRequest>
        {
            HttpMethod = HttpMethod.Post,
            Uri = "storage/read",
            Content = request
        };

        return await _httpRequestService.SendRequestAsync(requestMessage, cancellationToken);
    }

    public async Task<Result<SizeResponse>?> Size(SizeRequest request, CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request<SizeRequest>
        {
            HttpMethod = HttpMethod.Post,
            Uri = "storage/size",
            Content = request
        };

        return await _httpRequestService.SendRequestAsync<SizeRequest, Result<SizeResponse>>(requestMessage, cancellationToken);
    }

    public async Task<Result<WriteResponse>?> Write(WriteRequest request, CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request<WriteRequest>
        {
            HttpMethod = HttpMethod.Post,
            Uri = "storage/write",
            Content = request
        };

        return await _httpRequestService.SendRequestAsync<WriteRequest, Result<WriteResponse>>(requestMessage, cancellationToken);
    }
    #endregion

    #region Version
    public async Task<Result<VersionResponse>?> Version(CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request
        {
            HttpMethod = HttpMethod.Get,
            Uri = "version"
        };

        return await _httpRequestService.SendRequestAsync<Result<VersionResponse>>(requestMessage, cancellationToken);
    }
    #endregion

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}