namespace FlowSynx.Client.Requests.Plugins;

public class PluginsListRequest
{
    public string? Include { get; set; }
    public string? Exclude { get; set; }
    public bool? CaseSensitive { get; set; } = false;
    public string? MaxResults { get; set; }
    public string? Sorting { get; set; }
}