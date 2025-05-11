namespace FlowSynx.Client.Messages.Responses.Workflows;

public class WorkflowExecutionDetailsResponse
{
    public Guid Id { get; set; }
    public string? Status { get; set; }
    public DateTime ExecutionStart { get; set; }
    public DateTime? ExecutionEnd { get; set; }
}