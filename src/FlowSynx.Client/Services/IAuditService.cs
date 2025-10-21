using FlowSynx.Client.Messages.Requests.Audits;
using FlowSynx.Client.Messages.Requests.Workflows;
using FlowSynx.Client.Messages.Responses;
using FlowSynx.Client.Messages.Responses.Audits;

namespace FlowSynx.Client.Services;

/// <summary>
/// Provides methods for retrieving audit data such as audit logs and audit details from FlowSynx system.
/// </summary>
public interface IAuditService
{
    /// <summary>
    /// Retrieves a list of audits.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains an
    /// <see cref="HttpResult{T}"/> with a <see cref="Result{T}"/> holding a collection of <see cref="AuditsListResponse"/>.
    /// </returns>
    Task<HttpResult<PaginatedResult<AuditsListResponse>>> ListAsync(
        AuditsListRequest request,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves detailed information for a specific audit.
    /// </summary>
    /// <param name="request">The request containing the ID of the audit to retrieve.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains an
    /// <see cref="HttpResult{T}"/> with a <see cref="Result{T}"/> holding an <see cref="AuditDetailsResponse"/>.
    /// </returns>
    Task<HttpResult<Result<AuditDetailsResponse>>> DetailsAsync(
        AuditDetailsRequest request,
        CancellationToken cancellationToken = default);
}