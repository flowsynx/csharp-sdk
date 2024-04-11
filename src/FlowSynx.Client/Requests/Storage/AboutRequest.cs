namespace FlowSynx.Client.Requests.Storage;

public class AboutRequest
{
    public string? Path { get; set; } = string.Empty;
    public bool? Full { get; set; } = false;
}