namespace FlowSynx.Client.Messages.Requests.Workflows;

public class DeleteWorkflowTriggerRequest
{
    public required Guid WorkflowId { get; set; }
    public required Guid TriggerId { get; set; }
}