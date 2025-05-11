using FlowSynx.Client.Messages.Requests.Workflows;
using FlowSynx.Client.Messages.Responses.Workflows;
using FlowSynx.Client.Messages.Responses;

namespace FlowSynx.Client.Services;

public interface IWorkflowsService
{
    Task<HttpResult<Result<IEnumerable<WorkflowListResponse>>>> ListAsync(
        CancellationToken cancellationToken = default);

    Task<HttpResult<Result<AddWorkflowResponse>>> AddAsync(
        AddWorkflowRequest request,
        CancellationToken cancellationToken = default);

    Task<HttpResult<Result<WorkflowDetailsResponse>>> DetailsAsync(
        WorkflowDetailsRequest request,
        CancellationToken cancellationToken = default);

    Task<HttpResult<Result<Unit>>> UpdateAsync(
        UpdateWorkflowRequest request,
        CancellationToken cancellationToken = default);

    Task<HttpResult<Result<Unit>>> DeleteAsync(
        DeleteWorkflowRequest request,
        CancellationToken cancellationToken = default);

    Task<HttpResult<Result<IEnumerable<WorkflowExecutionListResponse>>>> ExecutionsAsync(
       WorkflowExecutionListRequest request,
       CancellationToken cancellationToken = default);

    Task<HttpResult<Result<Unit>>> ExecuteAsync(
        ExecuteWorkflowRequest request,
        CancellationToken cancellationToken = default);

    Task<HttpResult<Result<WorkflowExecutionDetailsResponse>>> ExecutionsDetailsAsync(
       WorkflowExecutionDetailsRequest request,
       CancellationToken cancellationToken = default);

    Task<HttpResult<Result<Unit>>> CancelExecutionsAsync(
        CancelWorkflowRequest request,
        CancellationToken cancellationToken = default);

    Task<HttpResult<Result<WorkflowExecutionLogsResponse>>> ExecutionsLogsAsync(
        WorkflowExecutionLogsRequest request,
        CancellationToken cancellationToken = default);

    Task<HttpResult<Result<WorkflowTaskExecutionDetailsResponse>>> TaskExecutionDetailsAsync(
        WorkflowTaskExecutionDetailsRequest request,
        CancellationToken cancellationToken = default);

    Task<HttpResult<Result<IEnumerable<WorkflowTaskExecutionLogsResponse>>>> TaskExecutionLogsAsync(
       WorkflowTaskExecutionLogsRequest request,
       CancellationToken cancellationToken = default);

    Task<HttpResult<Result<IEnumerable<WorkflowTriggersListResponse>>>> TriggersAsync(
        WorkflowTriggersListRequest request,
        CancellationToken cancellationToken = default);

    Task<HttpResult<Result<AddWorkflowTriggerResponse>>> AddTriggerAsync(
        AddWorkflowTriggerRequest request,
        CancellationToken cancellationToken = default);

    Task<HttpResult<Result<WorkflowTriggerDetailsResponse>>> TriggerDetailsAsync(
        WorkflowTriggerDetailsRequest request,
        CancellationToken cancellationToken = default);

    Task<HttpResult<Result<Unit>>> UpdateTriggerAsync(
        UpdateWorkflowTriggerRequest request,
        CancellationToken cancellationToken = default);

    Task<HttpResult<Result<Unit>>> DeleteTriggerAsync(
        DeleteWorkflowTriggerRequest request,
        CancellationToken cancellationToken = default);
}
