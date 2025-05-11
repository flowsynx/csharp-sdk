namespace FlowSynx.Client.Messages.Requests.Plugins;

public class UninstallPluginRequest
{
    public required string Type { get; set; }
    public required string Version { get; set; }
}