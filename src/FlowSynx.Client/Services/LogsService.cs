using FlowSynx.Client.Http;
using FlowSynx.Client.Messages.Responses;
using FlowSynx.Client.Messages.Requests;
using FlowSynx.Client.Messages.Requests.Logs;
using FlowSynx.Client.Messages.Responses.Logs;

namespace FlowSynx.Client.Services;

public class LogsService: ILogsService
{
    private readonly IHttpRequestHandler _httpRequestHandler;

    public LogsService(IHttpRequestHandler httpRequestHandler) => _httpRequestHandler = httpRequestHandler;

    public async Task<HttpResult<Result<IEnumerable<LogsListResponse>>>> ListAsync(
        LogsListRequest request,
        CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request<LogsListRequest>
        {
            HttpMethod = HttpMethod.Post,
            Uri = "logs",
            Content = request
        };

        return await _httpRequestHandler
            .SendRequestAsync<LogsListRequest, Result<IEnumerable<LogsListResponse>>>(requestMessage, cancellationToken);
    }
}