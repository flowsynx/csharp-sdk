using FlowSynx.Client.Messages.Responses.Health;
using FlowSynx.Client.Messages.Responses;
using FlowSynx.Client.Messages.Responses.Version;

namespace FlowSynx.Client.Services;

public interface IVersionService
{
    Task<HttpResult<Result<VersionResponse>>> GetVersion(
        CancellationToken cancellationToken = default);
}