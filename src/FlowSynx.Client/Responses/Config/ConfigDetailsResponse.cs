namespace FlowSynx.Client.Responses.Config;

public class ConfigDetailsResponse
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Type { get; set; }
    public Dictionary<string, object?>? Specifications { get; set; }
}