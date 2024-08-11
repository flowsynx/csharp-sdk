namespace FlowSynx.Client.Responses.Config;

public class ConfigListResponse
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Type { get; set; }
    public DateTimeOffset? ModifiedTime { get; set; }
}