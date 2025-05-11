using FlowSynx.Client.Messages.Responses.Health;
using FlowSynx.Client.Messages.Responses;

namespace FlowSynx.Client.Services;

/// <summary>
/// Provides functionality to perform health checks on the FlowSynx system.
/// </summary>
public interface IHealthCheckService
{
    /// <summary>
    /// Performs a health check by sending a request to the health endpoint.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains an
    /// <see cref="HttpResult{T}"/> with a <see cref="HealthCheckResponse"/> indicating the system's health status.
    /// </returns>
    Task<HttpResult<HealthCheckResponse>> Check(
        CancellationToken cancellationToken = default);
}