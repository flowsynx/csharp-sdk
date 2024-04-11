namespace FlowSynx.Client.Responses.Storage;

public class CheckResponse
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? Path { get; set; }
    public string State { get; set; } = string.Empty;
}