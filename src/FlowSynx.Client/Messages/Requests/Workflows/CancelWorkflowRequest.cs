namespace FlowSynx.Client.Messages.Requests.Workflows;

public class CancelWorkflowRequest
{
    public required Guid WorkflowId { get; set; }
    public required Guid WorkflowExecutionId { get; set; }
}