namespace FlowSynx.Client.Requests.Workflows;

public class UpdateWorkflowRequest
{
    public required Guid Id { get; set; }
    public required string Definition { get; set; }
}