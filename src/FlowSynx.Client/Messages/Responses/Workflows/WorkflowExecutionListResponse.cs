namespace FlowSynx.Client.Messages.Responses.Workflows;

public class WorkflowExecutionListResponse
{
    public Guid Id { get; set; }
    public string? Status { get; set; }
    public DateTime ExecutionStart { get; set; }
    public DateTime? ExecutionEnd { get; set; }
}