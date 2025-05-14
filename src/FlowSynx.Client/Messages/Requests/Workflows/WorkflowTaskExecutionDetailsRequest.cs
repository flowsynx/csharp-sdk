namespace FlowSynx.Client.Messages.Requests.Workflows;

public class WorkflowTaskExecutionDetailsRequest
{
    public required Guid WorkflowId { get; set; }
    public required Guid WorkflowExecutionId { get; set; }
    public required Guid WorkflowTaskExecutionId { get; set; }
}