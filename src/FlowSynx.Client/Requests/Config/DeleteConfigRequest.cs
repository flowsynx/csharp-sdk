namespace FlowSynx.Client.Requests.Config;

public class DeleteConfigRequest
{
    public string? Include { get; set; }
    public string? Exclude { get; set; }
    public string? MinAge { get; set; }
    public string? MaxAge { get; set; }
    public bool? CaseSensitive { get; set; } = false;
}