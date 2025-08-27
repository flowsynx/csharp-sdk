namespace FlowSynx.Client.Messages.Responses.PluginConfig;

public class PluginConfigDetailsResponse
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Type { get; set; }
    public required string Version { get; set; }
    public Dictionary<string, string?>? Specifications { get; set; }
}