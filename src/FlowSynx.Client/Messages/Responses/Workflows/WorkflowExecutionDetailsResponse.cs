namespace FlowSynx.Client.Messages.Responses.Workflows;

public class WorkflowExecutionDetailsResponse
{
    public Guid WorkflowId { get; set; }
    public Guid ExecutionId { get; set; }
    public string? Workflow { get; set; }
    public string? Status { get; set; }
    public DateTime ExecutionStart { get; set; }
    public DateTime? ExecutionEnd { get; set; }
}