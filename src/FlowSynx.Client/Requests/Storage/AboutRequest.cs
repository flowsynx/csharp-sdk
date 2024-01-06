namespace FlowSynx.Client.Requests.Storage;

public class AboutRequest
{
    public required string Path { get; set; }
    public bool? Full { get; set; } = false;
}