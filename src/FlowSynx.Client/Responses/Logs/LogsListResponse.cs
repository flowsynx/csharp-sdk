namespace FlowSynx.Client.Responses.Logs;

public class LogsListResponse
{
    public Guid Id { get; set; }
    public string Message { get; set; } = string.Empty;
    public string? Level { get; set; }
    public DateTime TimeStamp { get; set; }
    public string? Exception { get; set; }
}