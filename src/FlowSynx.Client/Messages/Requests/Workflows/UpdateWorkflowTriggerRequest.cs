namespace FlowSynx.Client.Messages.Requests.Workflows;

public class UpdateWorkflowTriggerRequest
{
    public required Guid WorkflowId { get; set; }
    public required Guid TriggerId { get; set; }
    public required string Status { get; set; }
    public required string Type { get; set; }
    public Dictionary<string, object> Properties { get; set; } = new();
}