namespace FlowSynx.Client.Messages.Requests.Workflows;

public class CancelWorkflowRequest
{
    public required string WorkflowId { get; set; }
    public required string WorkflowExecutionId { get; set; }
}