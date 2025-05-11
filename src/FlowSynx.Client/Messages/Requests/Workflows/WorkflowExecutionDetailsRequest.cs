namespace FlowSynx.Client.Messages.Requests.Workflows;

public class WorkflowExecutionDetailsRequest
{
    public required string WorkflowId { get; set; }
    public required string WorkflowExecutionId { get; set; }
}