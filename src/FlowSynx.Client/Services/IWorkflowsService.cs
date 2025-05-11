using FlowSynx.Client.Messages.Requests.Workflows;
using FlowSynx.Client.Messages.Responses.Workflows;
using FlowSynx.Client.Messages.Responses;

namespace FlowSynx.Client.Services;

/// <summary>
/// Provides methods to manage workflows, their executions, and triggers.
/// </summary>
public interface IWorkflowsService
{
    /// <summary>
    /// Retrieves a list of all available workflows.
    /// </summary>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
    /// <returns>A result containing a list of workflow summaries.</returns>
    Task<HttpResult<Result<IEnumerable<WorkflowListResponse>>>> ListAsync(
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Adds a new workflow.
    /// </summary>
    /// <param name="request">The workflow data to be added.</param>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
    /// <returns>A result containing the added workflow response.</returns>
    Task<HttpResult<Result<AddWorkflowResponse>>> AddAsync(
        AddWorkflowRequest request,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves detailed information about a specific workflow.
    /// </summary>
    /// <param name="request">The request specifying the workflow ID.</param>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
    /// <returns>A result containing the workflow details.</returns>
    Task<HttpResult<Result<WorkflowDetailsResponse>>> DetailsAsync(
        WorkflowDetailsRequest request,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an existing workflow.
    /// </summary>
    /// <param name="request">The update information for the workflow.</param>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
    /// <returns>A result indicating success or failure of the update.</returns>
    Task<HttpResult<Result<Unit>>> UpdateAsync(
        UpdateWorkflowRequest request,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a specified workflow.
    /// </summary>
    /// <param name="request">The request specifying which workflow to delete.</param>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
    /// <returns>A result indicating success or failure of the deletion.</returns>
    Task<HttpResult<Result<Unit>>> DeleteAsync(
        DeleteWorkflowRequest request,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a list of workflow executions.
    /// </summary>
    /// <param name="request">The request specifying filters for executions.</param>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
    /// <returns>A result containing a list of workflow executions.</returns>
    Task<HttpResult<Result<IEnumerable<WorkflowExecutionListResponse>>>> ExecutionsAsync(
       WorkflowExecutionListRequest request,
       CancellationToken cancellationToken = default);

    /// <summary>
    /// Executes a specific workflow.
    /// </summary>
    /// <param name="request">The request specifying which workflow to execute and with what parameters.</param>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
    /// <returns>A result indicating the execution status.</returns>
    Task<HttpResult<Result<Unit>>> ExecuteAsync(
        ExecuteWorkflowRequest request,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves detailed information about a specific workflow execution.
    /// </summary>
    /// <param name="request">The request specifying the execution ID.</param>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
    /// <returns>A result containing the execution details.</returns>
    Task<HttpResult<Result<WorkflowExecutionDetailsResponse>>> ExecutionsDetailsAsync(
       WorkflowExecutionDetailsRequest request,
       CancellationToken cancellationToken = default);

    /// <summary>
    /// Cancels a running workflow execution.
    /// </summary>
    /// <param name="request">The request identifying which execution to cancel.</param>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
    /// <returns>A result indicating success or failure of the cancellation.</returns>
    Task<HttpResult<Result<Unit>>> CancelExecutionsAsync(
        CancelWorkflowRequest request,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves logs for a specific workflow execution.
    /// </summary>
    /// <param name="request">The request specifying which execution's logs to retrieve.</param>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
    /// <returns>A result containing the execution logs.</returns>
    Task<HttpResult<Result<WorkflowExecutionLogsResponse>>> ExecutionsLogsAsync(
        WorkflowExecutionLogsRequest request,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves details of a specific task within a workflow execution.
    /// </summary>
    /// <param name="request">The request specifying the task execution.</param>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
    /// <returns>A result containing task execution details.</returns>
    Task<HttpResult<Result<WorkflowTaskExecutionDetailsResponse>>> TaskExecutionDetailsAsync(
        WorkflowTaskExecutionDetailsRequest request,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves logs for a specific task execution within a workflow.
    /// </summary>
    /// <param name="request">The request specifying which task execution logs to retrieve.</param>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
    /// <returns>A result containing the task execution logs.</returns>
    Task<HttpResult<Result<IEnumerable<WorkflowTaskExecutionLogsResponse>>>> TaskExecutionLogsAsync(
       WorkflowTaskExecutionLogsRequest request,
       CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a list of all triggers associated with workflows.
    /// </summary>
    /// <param name="request">The request specifying filter criteria for triggers.</param>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
    /// <returns>A result containing a list of workflow triggers.</returns>
    Task<HttpResult<Result<IEnumerable<WorkflowTriggersListResponse>>>> TriggersAsync(
        WorkflowTriggersListRequest request,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Adds a new trigger to a workflow.
    /// </summary>
    /// <param name="request">The request containing trigger details.</param>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
    /// <returns>A result containing the added trigger information.</returns>
    Task<HttpResult<Result<AddWorkflowTriggerResponse>>> AddTriggerAsync(
        AddWorkflowTriggerRequest request,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves details of a specific workflow trigger.
    /// </summary>
    /// <param name="request">The request identifying the trigger.</param>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
    /// <returns>A result containing trigger details.</returns>
    Task<HttpResult<Result<WorkflowTriggerDetailsResponse>>> TriggerDetailsAsync(
        WorkflowTriggerDetailsRequest request,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an existing workflow trigger.
    /// </summary>
    /// <param name="request">The update request for the trigger.</param>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
    /// <returns>A result indicating success or failure of the update.</returns>
    Task<HttpResult<Result<Unit>>> UpdateTriggerAsync(
        UpdateWorkflowTriggerRequest request,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a specific workflow trigger.
    /// </summary>
    /// <param name="request">The request specifying the trigger to delete.</param>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
    /// <returns>A result indicating success or failure of the deletion.</returns>
    Task<HttpResult<Result<Unit>>> DeleteTriggerAsync(
        DeleteWorkflowTriggerRequest request,
        CancellationToken cancellationToken = default);
}
