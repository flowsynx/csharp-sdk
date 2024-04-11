namespace FlowSynx.Client.Requests.Config;

public class AddConfigRequest
{
    public required string Name { get; set; }
    public required string Type { get; set; }
    public Dictionary<string, object?>? Specifications { get; set; }
}