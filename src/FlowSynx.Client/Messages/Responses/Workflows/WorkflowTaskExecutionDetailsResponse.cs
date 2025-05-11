namespace FlowSynx.Client.Messages.Responses.Workflows;

public class WorkflowTaskExecutionDetailsResponse
{
    public Guid Id { get; set; }
    public string? Status { get; set; }
    public string? Message { get; set; }
    public DateTime? StartTime { get; set; }
    public DateTime? EndTime { get; set; }
}