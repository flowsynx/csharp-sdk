namespace FlowSynx.Client.Messages.Requests.Workflows;

public class WorkflowTaskExecutionLogsRequest
{
    public required Guid WorkflowId { get; set; }
    public required Guid WorkflowExecutionId { get; set; }
    public required Guid WorkflowTaskExecutionId { get; set; }
    public int? Page { get; set; }
    public int? PageSize { get; set; }
}