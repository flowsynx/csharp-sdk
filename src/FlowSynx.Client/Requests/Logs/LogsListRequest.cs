namespace FlowSynx.Client.Requests.Logs;

public class LogsListRequest
{
    public string? Level { get; set; }
    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }
    public string? Message { get; set; }
}