namespace FlowSynx.Client.Responses.PluginConfig;

public class PluginConfigListResponse
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Type { get; set; }
    public DateTimeOffset? ModifiedTime { get; set; }
}