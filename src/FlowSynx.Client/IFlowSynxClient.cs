using FlowSynx.Client.Requests.Config;
using FlowSynx.Client.Requests.Plugins;
using FlowSynx.Client.Requests.Storage;
using FlowSynx.Client.Responses.Storage;
using FlowSynx.Client.Responses;
using FlowSynx.Client.Responses.Config;
using FlowSynx.Client.Responses.Health;
using FlowSynx.Client.Responses.Plugins;
using FlowSynx.Client.Responses.Version;
using FlowSynx.Client.Requests.Logs;
using FlowSynx.Client.Responses.Logs;

namespace FlowSynx.Client;

public interface IFlowSynxClient : IDisposable
{
    void ChangeConnection(string baseAddress);

    #region Configuration
    Task<Result<AddConfigResponse>> AddConfig(AddConfigRequest request, CancellationToken cancellationToken = default);
    Task<Result<ConfigDetailsResponse>> ConfigDetails(ConfigDetailsRequest request, CancellationToken cancellationToken = default);
    Task<Result<IEnumerable<ConfigListResponse>>> ConfigList(ConfigListRequest request, CancellationToken cancellationToken = default);
    Task<Result<IEnumerable<DeleteConfigResponse>>> DeleteConfig(DeleteConfigRequest request, CancellationToken cancellationToken = default);
    #endregion

    #region Health
    Task<HealthCheckResponse> Health(CancellationToken cancellationToken = default);
    #endregion

    #region MyRegion

    Task<Result<IEnumerable<LogsListResponse>>> LogsList(LogsListRequest request, CancellationToken cancellationToken = default);
    #endregion

    #region Plugins
    Task<Result<PluginDetailsResponse>> PluginDetails(PluginDetailsRequest request, CancellationToken cancellationToken = default);
    Task<Result<IEnumerable<PluginsListResponse>>> PluginsList(PluginsListRequest request, CancellationToken cancellationToken = default);
    #endregion

    #region Storage
    Task<Result<AboutResponse>> About(AboutRequest request, CancellationToken cancellationToken = default);
    Task<Result<CopyResponse>> Copy(CopyRequest request, CancellationToken cancellationToken = default);
    Task<Result<CheckResponse>> Check(CheckRequest request, CancellationToken cancellationToken = default);
    Task<Result<CompressResponse>> Compress(CompressRequest request, CancellationToken cancellationToken = default);
    Task<Result<DeleteFileResponse>> DeleteFile(DeleteFileRequest request, CancellationToken cancellationToken = default);
    Task<Result<DeleteResponse>> Delete(DeleteRequest request, CancellationToken cancellationToken = default);
    Task<Result<ExistResponse>> Exist(ExistRequest request, CancellationToken cancellationToken = default);
    Task<Result<IEnumerable<ListResponse>>> List(ListRequest request, CancellationToken cancellationToken = default);
    Task<Result<MakeDirectoryResponse>> MakeDirectory(MakeDirectoryRequest request, CancellationToken cancellationToken = default);
    Task<Result<MoveResponse>> Move(MoveRequest request, CancellationToken cancellationToken = default);
    Task<Result<PurgeDirectoryResponse>> PurgeDirectory(PurgeDirectoryRequest request, CancellationToken cancellationToken = default);
    Task<Stream> Read(ReadRequest request, CancellationToken cancellationToken = default);
    Task<Result<SizeResponse>> Size(SizeRequest request, CancellationToken cancellationToken = default);
    Task<Result<WriteResponse>> Write(WriteRequest request, CancellationToken cancellationToken = default);
    #endregion

    #region Version
    Task<Result<VersionResponse>> Version(CancellationToken cancellationToken = default);
    #endregion
}