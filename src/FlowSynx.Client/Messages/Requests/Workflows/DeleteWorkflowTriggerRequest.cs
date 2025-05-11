namespace FlowSynx.Client.Messages.Requests.Workflows;

public class DeleteWorkflowTriggerRequest
{
    public required string WorkflowId { get; set; }
    public required string TriggerId { get; set; }
}