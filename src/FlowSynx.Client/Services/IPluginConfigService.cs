using FlowSynx.Client.Messages.Responses.PluginConfig;
using FlowSynx.Client.Messages.Responses;
using FlowSynx.Client.Messages.Requests.PluginConfig;

namespace FlowSynx.Client.Services;

/// <summary>
/// Defines a contract for managing plugin configuration, including listing, adding, updating, retrieving, and deleting plugin configurations.
/// </summary>
public interface IPluginConfigService
{
    /// <summary>
    /// Retrieves a list of all plugin configurations.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains an
    /// <see cref="HttpResult{T}"/> with a <see cref="Result{T}"/> holding a collection of <see cref="PluginConfigListResponse"/>.
    /// </returns>
    Task<HttpResult<Result<IEnumerable<PluginConfigListResponse>>>> ListAsync(
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Adds a new plugin configuration.
    /// </summary>
    /// <param name="request">The request containing the details of the plugin configuration to be added.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains an
    /// <see cref="HttpResult{T}"/> with a <see cref="Result{T}"/> holding an <see cref="AddPluginConfigResponse"/>.
    /// </returns>
    Task<HttpResult<Result<AddPluginConfigResponse>>> AddAsync(
        AddPluginConfigRequest request,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves the details of a specific plugin configuration.
    /// </summary>
    /// <param name="request">The request containing the identifier of the plugin configuration to retrieve.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains an
    /// <see cref="HttpResult{T}"/> with a <see cref="Result{T}"/> holding a <see cref="PluginConfigDetailsResponse"/>.
    /// </returns>
    Task<HttpResult<Result<PluginConfigDetailsResponse>>> DetailsAsync(
        PluginConfigDetailsRequest request,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an existing plugin configuration.
    /// </summary>
    /// <param name="request">The request containing the updated plugin configuration information.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains an
    /// <see cref="HttpResult{T}"/> with a <see cref="Result{T}"/> indicating success or failure.
    /// </returns>
    Task<HttpResult<Result<Unit>>> UpdateAsync(
        UpdatePluginConfigRequest request,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a specified plugin configuration.
    /// </summary>
    /// <param name="request">The request containing the identifier of the plugin configuration to delete.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains an
    /// <see cref="HttpResult{T}"/> with a <see cref="Result{T}"/> indicating success or failure.
    /// </returns>
    Task<HttpResult<Result<Unit>>> DeleteAsync(
        DeletePluginConfigRequest request,
        CancellationToken cancellationToken = default);
}