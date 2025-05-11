using FlowSynx.Client.Messages.Responses.Audits;
using FlowSynx.Client.Messages.Responses;

namespace FlowSynx.Client.Services;

public interface IAuditService
{
    Task<HttpResult<Result<IEnumerable<AuditsListResponse>>>> ListAsync(
        CancellationToken cancellationToken = default);
}