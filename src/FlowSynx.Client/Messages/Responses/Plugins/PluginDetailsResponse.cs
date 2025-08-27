namespace FlowSynx.Client.Messages.Responses.Plugins;

public class PluginDetailsResponse
{
    public required Guid Id { get; set; }
    public required string Type { get; set; }
    public required string Version { get; set; }
    public string? Description { get; set; }
    public List<PluginDetailsSpecification>? Specifications { get; set; } = new List<PluginDetailsSpecification>();
}