using System.Net;

namespace FlowSynx.Client.Responses;

public class HttpResult<TResult>
{
    public int StatusCode { get; set; }
    public IEnumerable<KeyValuePair<string, IEnumerable<string>>> Headers { get; set; } = new List<KeyValuePair<string, IEnumerable<string>>>();
    public required TResult Payload { get; set; }
}