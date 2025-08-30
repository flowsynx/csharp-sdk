namespace FlowSynx.Client.Messages.Responses.Workflows;

public class ExecuteWorkflowResponse
{
    public required Guid WorkflowId { get; set; }
    public required Guid ExecutionId { get; set; }
    public required DateTime StartedAt { get; set; }
}