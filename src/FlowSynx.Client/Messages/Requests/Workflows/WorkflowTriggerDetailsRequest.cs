namespace FlowSynx.Client.Messages.Requests.Workflows;

public class WorkflowTriggerDetailsRequest
{
    public required string WorkflowId { get; set; }
    public required string TriggerId { get; set; }
}