using FlowSynx.Client.Messages.Requests.Logs;
using FlowSynx.Client.Messages.Responses.Logs;
using FlowSynx.Client.Messages.Responses;

namespace FlowSynx.Client.Services;

public interface ILogsService
{
    Task<HttpResult<Result<IEnumerable<LogsListResponse>>>> ListAsync(
        LogsListRequest request,
        CancellationToken cancellationToken = default);
}