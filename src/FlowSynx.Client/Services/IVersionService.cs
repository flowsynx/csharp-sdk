using FlowSynx.Client.Messages.Responses;
using FlowSynx.Client.Messages.Responses.Version;

namespace FlowSynx.Client.Services;

/// <summary>
/// Defines a contract for retrieving the current version information of the FlowSynx system.
/// </summary>
public interface IVersionService
{
    /// <summary>
    /// Retrieves the current version details.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains an
    /// <see cref="HttpResult{T}"/> with a <see cref="Result{T}"/> holding a <see cref="VersionResponse"/>.
    /// </returns>
    Task<HttpResult<Result<VersionResponse>>> GetVersion(
        CancellationToken cancellationToken = default);
}
