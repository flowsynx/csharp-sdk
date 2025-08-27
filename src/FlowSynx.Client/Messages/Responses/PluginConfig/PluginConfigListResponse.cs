namespace FlowSynx.Client.Messages.Responses.PluginConfig;

public class PluginConfigListResponse
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Type { get; set; }
    public required string Version { get; set; }
    public DateTimeOffset? ModifiedTime { get; set; }
}