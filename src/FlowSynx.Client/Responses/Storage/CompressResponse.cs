namespace FlowSynx.Client.Responses.Storage;

public class CompressResponse
{
    public Stream? Content { get; set; }
    public long Length => Content?.Length ?? 0;
    public string? ContentType { get; set; }
    public string? Md5 { get; set; }
}