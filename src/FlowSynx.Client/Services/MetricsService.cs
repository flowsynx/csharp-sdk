using FlowSynx.Client.Http;
using FlowSynx.Client.Messages.Requests;
using FlowSynx.Client.Messages.Responses;
using FlowSynx.Client.Messages.Responses.Metrics.Query;

namespace FlowSynx.Client.Services;

public class MetricsService : IMetricsService
{
    private readonly IHttpRequestHandler _httpRequestHandler;

    public MetricsService(IHttpRequestHandler httpRequestHandler) => _httpRequestHandler = httpRequestHandler;

    public async Task<HttpResult<Result<SummaryResponse>>> GetWorkflowSummary(
        CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request
        {
            HttpMethod = HttpMethod.Get,
            Uri = "metrics"
        };

        return await _httpRequestHandler
            .SendRequestAsync<Result<SummaryResponse>>(requestMessage, cancellationToken);
    }
}