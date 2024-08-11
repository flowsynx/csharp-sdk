namespace FlowSynx.Client.Requests.Config;

public class DeleteConfigRequest
{
    public string? Include { get; set; }
    public string? Exclude { get; set; }
    public string? MinimumAge { get; set; }
    public string? MaximumAge { get; set; }
    public bool CaseSensitive { get; set; } = false;
}