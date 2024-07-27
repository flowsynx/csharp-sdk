namespace FlowSynx.Client.Responses.Logs;

public class LogsListResponse
{
    public string? UserName { get; set; }
    public string? Machine { get; set; }
    public DateTime TimeStamp { get; set; }
    public required string Message { get; set; }
    public required string Level { get; set; }
}
