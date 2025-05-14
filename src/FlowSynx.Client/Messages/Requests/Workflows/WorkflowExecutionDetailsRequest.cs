namespace FlowSynx.Client.Messages.Requests.Workflows;

public class WorkflowExecutionDetailsRequest
{
    public required Guid WorkflowId { get; set; }
    public required Guid WorkflowExecutionId { get; set; }
}