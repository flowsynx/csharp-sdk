namespace FlowSynx.Client.Messages.Requests.Workflows;

public class RejectWorkflowRequest
{
    public required Guid WorkflowId { get; set; }
    public required Guid WorkflowExecutionId { get; set; }
    public required Guid WorkflowExecutionApprovalId { get; set; }
}