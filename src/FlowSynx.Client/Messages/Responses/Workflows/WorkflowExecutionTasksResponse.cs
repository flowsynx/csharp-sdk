namespace FlowSynx.Client.Messages.Responses.Workflows;

public class WorkflowExecutionTasksResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Guid WorkflowId { get; set; }
    public Guid WorkflowExecutionId { get; set; }
    public string? Status { get; set; }
    public string? Message { get; set; }
    public DateTime? StartTime { get; set; }
    public DateTime? EndTime { get; set; }
}