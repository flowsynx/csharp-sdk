using FlowSynx.Client.Messages.Requests.Logs;
using FlowSynx.Client.Messages.Responses.Logs;
using FlowSynx.Client.Messages.Responses;

namespace FlowSynx.Client.Services;

/// <summary>
/// Defines a contract for retrieving logs from the system.
/// </summary>
public interface ILogsService
{
    /// <summary>
    /// Retrieves a list of logs based on the specified filtering and pagination criteria.
    /// </summary>
    /// <param name="request">The request containing parameters for filtering and paging log entries.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains an
    /// <see cref="HttpResult{T}"/> with a <see cref="Result{T}"/> holding a collection of <see cref="LogsListResponse"/>.
    /// </returns>
    Task<HttpResult<Result<IEnumerable<LogsListResponse>>>> ListAsync(
        LogsListRequest request,
        CancellationToken cancellationToken = default);
}
