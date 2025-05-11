namespace FlowSynx.Client.Messages.Requests.Workflows;

public class UpdateWorkflowTriggerRequest
{
    public required string WorkflowId { get; set; }
    public required string TriggerId { get; set; }
    public required string Status { get; set; }
    public required string Type { get; set; }
    public Dictionary<string, object> Properties { get; set; } = new();
}