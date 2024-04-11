namespace FlowSynx.Client.Requests.Storage;

public class ReadRequest
{
    public required string Path { get; set; }
    public bool? Hashing { get; set; } = false;
}