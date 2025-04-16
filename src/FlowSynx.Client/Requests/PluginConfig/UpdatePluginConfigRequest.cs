namespace FlowSynx.Client.Requests.PluginConfig;

public class UpdatePluginConfigRequest
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Type { get; set; }
    public required string Version { get; set; }
    public Dictionary<string, object?>? Specifications { get; set; }
}