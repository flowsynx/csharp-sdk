namespace FlowSynx.Client.Messages.Requests.Workflows;

public class WorkflowTaskExecutionLogsRequest
{
    public required string WorkflowId { get; set; }
    public required string WorkflowExecutionId { get; set; }
    public required string WorkflowTaskExecutionId { get; set; }
}