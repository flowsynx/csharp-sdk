namespace FlowSynx.Client.Messages.Responses.Plugins;

public class PluginsListResponse
{
    public required Guid Id { get; set; }
    public required string Type { get; set; }
    public required string Version { get; set; }
    public string? Description { get; set; }
}