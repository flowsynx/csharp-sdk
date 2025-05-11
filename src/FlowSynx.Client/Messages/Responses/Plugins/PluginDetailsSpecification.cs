namespace FlowSynx.Client.Messages.Responses.Plugins;

public class PluginDetailsSpecification
{
    public required string Key { get; set; }
    public required string Type { get; set; }
    public bool Required { get; set; } = false;
}