namespace FlowSynx.Client.Requests.Plugins;

public class InstallPluginRequest
{
    public required string Type { get; set; }
    public required string Version { get; set; }
}