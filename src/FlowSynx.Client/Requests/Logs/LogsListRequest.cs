namespace FlowSynx.Client.Requests.Logs;

public class LogsListRequest
{
    public string? MinAge { get; set; }
    public string? MaxAge { get; set; }
    public string? Level { get; set; }
}