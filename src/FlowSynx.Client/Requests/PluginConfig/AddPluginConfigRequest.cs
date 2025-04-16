
namespace FlowSynx.Client.Requests.PluginConfig;

public class AddPluginConfigRequest
{
    public required string Name { get; set; }
    public required string Type { get; set; }
    public required string Version { get; set; }
    public Dictionary<string, object?>? Specifications { get; set; }
}