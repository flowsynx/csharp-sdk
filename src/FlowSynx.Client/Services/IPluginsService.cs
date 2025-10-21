using FlowSynx.Client.Messages.Requests.Plugins;
using FlowSynx.Client.Messages.Responses.Plugins;
using FlowSynx.Client.Messages.Responses;

namespace FlowSynx.Client.Services;

/// <summary>
/// Defines a contract for managing plugins, including listing, installing, updating, retrieving details, and uninstalling plugins.
/// </summary>
public interface IPluginsService
{
    /// <summary>
    /// Retrieves a list of all installed or available plugins.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains an
    /// <see cref="HttpResult{T}"/> with a <see cref="Result{T}"/> holding a collection of <see cref="PluginsListResponse"/>.
    /// </returns>
    Task<HttpResult<PaginatedResult<PluginsListResponse>>> ListAsync(
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Installs a new plugin based on the provided request.
    /// </summary>
    /// <param name="request">The request containing the plugin installation data.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains an
    /// <see cref="HttpResult{T}"/> with a <see cref="Result{T}"/> indicating success or failure.
    /// </returns>
    Task<HttpResult<Result<Unit>>> InstallAsync(
        InstallPluginRequest request,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves detailed information about a specific plugin.
    /// </summary>
    /// <param name="request">The request containing the identifier of the plugin to retrieve.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains an
    /// <see cref="HttpResult{T}"/> with a <see cref="Result{T}"/> holding a <see cref="PluginDetailsResponse"/>.
    /// </returns>
    Task<HttpResult<Result<PluginDetailsResponse>>> DetailsAsync(
        PluginDetailsRequest request,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an existing plugin with new configuration or binary data.
    /// </summary>
    /// <param name="request">The request containing the updated plugin information.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains an
    /// <see cref="HttpResult{T}"/> with a <see cref="Result{T}"/> indicating success or failure.
    /// </returns>
    Task<HttpResult<Result<Unit>>> UpdateAsync(
        UpdatePluginRequest request,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Uninstalls the specified plugin from the FlowSynx system.
    /// </summary>
    /// <param name="request">The request containing the identifier of the plugin to uninstall.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains an
    /// <see cref="HttpResult{T}"/> with a <see cref="Result{T}"/> indicating success or failure.
    /// </returns>
    Task<HttpResult<Result<Unit>>> UninstallAsync(
        UninstallPluginRequest request,
        CancellationToken cancellationToken = default);
}