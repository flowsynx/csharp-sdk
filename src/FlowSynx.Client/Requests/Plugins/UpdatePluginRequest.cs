namespace FlowSynx.Client.Requests.Plugins;

public class UpdatePluginRequest
{
    public required string Type { get; set; }
    public required string OldVersion { get; set; }
    public required string NewVersion { get; set; }
}