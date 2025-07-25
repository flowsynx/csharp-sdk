namespace FlowSynx.Client.Messages.Requests.Workflows;

public class RejectWorkflowRequest
{
    public required string WorkflowId { get; set; }
    public required string WorkflowExecutionId { get; set; }
    public required string WorkflowExecutionApprovalId { get; set; }
}