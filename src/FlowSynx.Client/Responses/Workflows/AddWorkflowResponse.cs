namespace FlowSynx.Client.Responses.Workflows;

public class AddWorkflowResponse
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
}