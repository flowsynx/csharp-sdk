namespace FlowSynx.Client.Responses.Connectors;

public class ConnectorDetailsSpecification
{
    public required string Key { get; set; }
    public required string Type { get; set; }
    public bool Required { get; set; } = false;
}