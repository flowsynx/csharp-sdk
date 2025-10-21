namespace FlowSynx.Client.Messages.Requests.Workflows;

public class WorkflowExecutionPendingApprovalsRequest
{
    public required Guid WorkflowId { get; set; }
    public required Guid WorkflowExecutionId { get; set; }
    public int? Page { get; set; }
    public int? PageSize { get; set; }
}