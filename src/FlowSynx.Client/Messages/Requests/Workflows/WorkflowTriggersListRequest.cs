namespace FlowSynx.Client.Messages.Requests.Workflows;

public class WorkflowTriggersListRequest
{
    public required Guid WorkflowId { get; set; }
    public int? Page { get; set; }
    public int? PageSize { get; set; }
}