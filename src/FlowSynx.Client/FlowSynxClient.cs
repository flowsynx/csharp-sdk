using FlowSynx.Client.Exceptions;
using FlowSynx.Client.Http;
using FlowSynx.Client.Requests;
using FlowSynx.Client.Requests.Config;
using FlowSynx.Client.Requests.Logs;
using FlowSynx.Client.Requests.Plugins;
using FlowSynx.Client.Requests.Storage;
using FlowSynx.Client.Responses;
using FlowSynx.Client.Responses.Config;
using FlowSynx.Client.Responses.Health;
using FlowSynx.Client.Responses.Logs;
using FlowSynx.Client.Responses.Plugins;
using FlowSynx.Client.Responses.Storage;
using FlowSynx.Client.Responses.Version;

namespace FlowSynx.Client;

public class FlowSynxClient : IFlowSynxClient
{
    private IHttpRequestService _httpRequestService;

    public FlowSynxClient(FlowSynxClientConnection clientConnection)
    {
        var baseAddress = clientConnection.BaseAddress;
        if (string.IsNullOrEmpty(baseAddress))
            baseAddress = FlowSynxEnvironments.GetDefaultHttpEndpoint();

        CheckAddress(baseAddress);
        _httpRequestService = HttpRequestService.Create(baseAddress);
    }

    public void ChangeConnection(string baseAddress)
    {
        CheckAddress(baseAddress);
        _httpRequestService = HttpRequestService.Create(baseAddress);
    }

    #region private methods
    private void CheckAddress(string baseAddress)
    {
        if (!IsUrlValid(baseAddress))
            throw new FlowSynxClientException($"Entered address {baseAddress} is not valid. Please check it and try again!");
    }

    private bool IsUrlValid(string url) => Uri.TryCreate(url, UriKind.Absolute, out var uriResult)
                                           && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
    #endregion

    #region Configuration
    public async Task<Result<AddConfigResponse>> AddConfig(AddConfigRequest request, CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request<AddConfigRequest>
        {
            HttpMethod = HttpMethod.Post,
            Uri = "config/add",
            Content = request
        };

        var result = await _httpRequestService.SendRequestAsync<AddConfigRequest, Result<AddConfigResponse>>(requestMessage, cancellationToken);
        return result.Payload;
    }

    public async Task<Result<ConfigDetailsResponse>> ConfigDetails(ConfigDetailsRequest request, CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request
        {
            HttpMethod = HttpMethod.Get,
            Uri = $"config/details/{request.Name}"
        };

        var result = await _httpRequestService.SendRequestAsync<Result<ConfigDetailsResponse>>(requestMessage, cancellationToken);
        return result.Payload;
    }

    public async Task<Result<IEnumerable<ConfigListResponse>>> ConfigList(ConfigListRequest request, CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request<ConfigListRequest>
        {
            HttpMethod = HttpMethod.Post,
            Uri = "config",
            Content = request
        };

        var result = await _httpRequestService.SendRequestAsync<ConfigListRequest, Result<IEnumerable<ConfigListResponse>>>(requestMessage, cancellationToken);
        return result.Payload;
    }

    public async Task<Result<DeleteConfigResponse>> DeleteConfig(DeleteConfigRequest request, CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request<DeleteConfigRequest>
        {
            HttpMethod = HttpMethod.Delete,
            Uri = "config/delete",
            Content = request
        };

        var result = await _httpRequestService.SendRequestAsync<DeleteConfigRequest, Result<DeleteConfigResponse>>(requestMessage, cancellationToken);
        return result.Payload;
    }
    #endregion

    #region Health
    public async Task<HealthCheckResponse> Health(CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request
        {
            HttpMethod = HttpMethod.Get,
            Uri = "health",
        };

        var result = await _httpRequestService.SendRequestAsync<HealthCheckResponse>(requestMessage, cancellationToken);
        return result.Payload;
    }
    #endregion

    #region Logs
    public async Task<Result<IEnumerable<LogsListResponse>>> LogsList(LogsListRequest request, CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request<LogsListRequest>
        {
            HttpMethod = HttpMethod.Post,
            Uri = "logs",
            Content = request
        };

        var result = await _httpRequestService.SendRequestAsync<LogsListRequest, Result<IEnumerable<LogsListResponse>>>(requestMessage, cancellationToken);
        return result.Payload;
    }
    #endregion

    #region Plugins

    public async Task<Result<PluginDetailsResponse>> PluginDetails(PluginDetailsRequest request, CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request<PluginDetailsRequest>
        {
            HttpMethod = HttpMethod.Post,
            Uri = "plugins/details",
            Content = request
        };

        var result = await _httpRequestService.SendRequestAsync<Result<PluginDetailsResponse>>(requestMessage, cancellationToken);
        return result.Payload;
    }

    public async Task<Result<IEnumerable<PluginsListResponse>>> PluginsList(PluginsListRequest request, CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request<PluginsListRequest>
        {
            HttpMethod = HttpMethod.Post,
            Uri = "plugins",
            Content = request
        };

        var result = await _httpRequestService.SendRequestAsync<PluginsListRequest, Result<IEnumerable<PluginsListResponse>>>(requestMessage, cancellationToken);
        return result.Payload;
    }
    #endregion

    #region Storage
    public async Task<Result<AboutResponse>> About(AboutRequest request, CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request<AboutRequest>
        {
            HttpMethod = HttpMethod.Post,
            Uri = "storage/about",
            Content = request
        };

        var result = await _httpRequestService.SendRequestAsync<AboutRequest, Result<AboutResponse>>(requestMessage, cancellationToken);
        return result.Payload;
    }

    public async Task<Result<CopyResponse>> Copy(CopyRequest request, CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request<CopyRequest>
        {
            HttpMethod = HttpMethod.Post,
            Uri = "storage/copy",
            Content = request
        };

        var result = await _httpRequestService.SendRequestAsync<CopyRequest, Result<CopyResponse>>(requestMessage, cancellationToken);
        return result.Payload;
    }

    public async Task<Result<CheckResponse>> Check(CheckRequest request, CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request<CheckRequest>
        {
            HttpMethod = HttpMethod.Post,
            Uri = "storage/check",
            Content = request
        };

        var result = await _httpRequestService.SendRequestAsync<CheckRequest, Result<CheckResponse>>(requestMessage, cancellationToken);
        return result.Payload;
    }

    public async Task<Result<CompressResponse>> Compress(CompressRequest request, CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request<CompressRequest>
        {
            HttpMethod = HttpMethod.Post,
            Uri = "storage/compress",
            Content = request
        };

        var result = await _httpRequestService.SendRequestAsync<CompressRequest, Result<CompressResponse>>(requestMessage, cancellationToken);
        return result.Payload;
    }

    public async Task<Result<DeleteFileResponse>> DeleteFile(DeleteFileRequest request, CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request<DeleteFileRequest>
        {
            HttpMethod = HttpMethod.Delete,
            Uri = "storage/deletefile",
            Content = request
        };


        var result = await _httpRequestService.SendRequestAsync<DeleteFileRequest, Result<DeleteFileResponse>>(requestMessage, cancellationToken);
        return result.Payload;
    }

    public async Task<Result<DeleteResponse>> Delete(DeleteRequest request, CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request<DeleteRequest>
        {
            HttpMethod = HttpMethod.Delete,
            Uri = "storage/delete",
            Content = request
        };

        var result = await _httpRequestService.SendRequestAsync<DeleteRequest, Result<DeleteResponse>>(requestMessage, cancellationToken);
        return result.Payload;
    }

    public async Task<Result<ExistResponse>> Exist(ExistRequest request, CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request<ExistRequest>
        {
            HttpMethod = HttpMethod.Post,
            Uri = "storage/exist",
            Content = request
        };

        var result = await _httpRequestService.SendRequestAsync<ExistRequest, Result<ExistResponse>>(requestMessage, cancellationToken);
        return result.Payload;
    }

    public async Task<Result<IEnumerable<ListResponse>>> List(ListRequest request, CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request<ListRequest>
        {
            HttpMethod = HttpMethod.Post,
            Uri = "storage/list",
            Content = request
        };

        var result = await _httpRequestService.SendRequestAsync<ListRequest, Result<IEnumerable<ListResponse>>>(requestMessage, cancellationToken);
        return result.Payload;
    }

    public async Task<Result<MakeDirectoryResponse>> MakeDirectory(MakeDirectoryRequest request, CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request<MakeDirectoryRequest>
        {
            HttpMethod = HttpMethod.Post,
            Uri = "storage/mkdir",
            Content = request
        };

        var result = await _httpRequestService.SendRequestAsync<MakeDirectoryRequest, Result<MakeDirectoryResponse>>(requestMessage, cancellationToken);
        return result.Payload;
    }

    public async Task<Result<MoveResponse>> Move(MoveRequest request, CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request<MoveRequest>
        {
            HttpMethod = HttpMethod.Post,
            Uri = "storage/move",
            Content = request
        };

        var result = await _httpRequestService.SendRequestAsync<MoveRequest, Result<MoveResponse>>(requestMessage, cancellationToken);
        return result.Payload;
    }

    public async Task<Result<PurgeDirectoryResponse>> PurgeDirectory(PurgeDirectoryRequest request, CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request<PurgeDirectoryRequest>
        {
            HttpMethod = HttpMethod.Post,
            Uri = "storage/purge",
            Content = request
        };

        var result = await _httpRequestService.SendRequestAsync<PurgeDirectoryRequest, Result<PurgeDirectoryResponse>>(requestMessage, cancellationToken);
        return result.Payload;
    }

    public async Task<Stream> Read(ReadRequest request, CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request<ReadRequest>
        {
            HttpMethod = HttpMethod.Post,
            Uri = "storage/read",
            Content = request
        };

        var result = await _httpRequestService.SendRequestAsync(requestMessage, cancellationToken);
        return result.Payload;
    }

    public async Task<Result<SizeResponse>> Size(SizeRequest request, CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request<SizeRequest>
        {
            HttpMethod = HttpMethod.Post,
            Uri = "storage/size",
            Content = request
        };

        var result = await _httpRequestService.SendRequestAsync<SizeRequest, Result<SizeResponse>>(requestMessage, cancellationToken);
        return result.Payload;
    }

    public async Task<Result<WriteResponse>> Write(WriteRequest request, CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request<WriteRequest>
        {
            HttpMethod = HttpMethod.Post,
            Uri = "storage/write",
            Content = request
        };

        var result = await _httpRequestService.SendRequestAsync<WriteRequest, Result<WriteResponse>>(requestMessage, cancellationToken);
        return result.Payload;
    }
    #endregion

    #region Version
    public async Task<Result<VersionResponse>> Version(CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request
        {
            HttpMethod = HttpMethod.Get,
            Uri = "version"
        };

        var result = await _httpRequestService.SendRequestAsync<Result<VersionResponse>>(requestMessage, cancellationToken);
        return result.Payload;
    }
    #endregion

    public void Dispose()
    {
        _httpRequestService.Dispose();
    }
}