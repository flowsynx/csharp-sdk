namespace FlowSynx.Client.Requests.Storage;

public class ListRequest
{
    public required string Path { get; set; }
    public string? Kind { get; set; } = "FileAndDirectory";
    public string? Include { get; set; }
    public string? Exclude { get; set; }
    public string? MinAge { get; set; }
    public string? MaxAge { get; set; }
    public string? MinSize { get; set; }
    public string? MaxSize { get; set; }
    public bool? Full { get; set; } = true;
    public string? Sorting { get; set; }
    public bool? CaseSensitive { get; set; } = false;
    public bool? Recurse { get; set; } = false;
    public string? MaxResults { get; set; }
    public bool? IncludeMetadata { get; set; } = false;
}