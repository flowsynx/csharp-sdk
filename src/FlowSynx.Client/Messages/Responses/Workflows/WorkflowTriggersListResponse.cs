namespace FlowSynx.Client.Messages.Responses.Workflows;

public class WorkflowTriggersListResponse
{
    public Guid Id { get; set; }
    public string? Type { get; set; }
    public string? Status { get; set; }
    public Dictionary<string, object> Properties { get; set; } = new Dictionary<string, object>();
    public DateTime? LastModified { get; set; }
}