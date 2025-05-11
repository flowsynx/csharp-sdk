namespace FlowSynx.Client.Messages.Responses.Workflows;

public class WorkflowTaskExecutionLogsResponse
{
    public Guid Id { get; set; }
    public string Message { get; set; } = string.Empty;
    public string? Level { get; set; }
    public DateTime TimeStamp { get; set; }
    public string? Exception { get; set; }
}