using FlowSynx.Client.Messages.Responses;
using FlowSynx.Client.Messages.Responses.Metrics.Query;
using FlowSynx.Client.Messages.Responses.Version;

namespace FlowSynx.Client.Services;

/// <summary>
/// Defines a service for retrieving metrics-related information.
/// </summary>
public interface IMetricsService
{
    /// <summary>
    /// Retrieves the workflow summary asynchronously.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains an
    /// <see cref="HttpResult{T}"/> with a <see cref="Result{T}"/> holding a <see cref="VersionResponse"/>.
    /// </returns>
    Task<HttpResult<Result<SummaryResponse>>> GetWorkflowSummary(
        CancellationToken cancellationToken = default);
}
