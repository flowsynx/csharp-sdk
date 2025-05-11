using FlowSynx.Client.Http;
using FlowSynx.Client.Messages.Responses;
using FlowSynx.Client.Messages.Requests;
using FlowSynx.Client.Messages.Responses.Health;

namespace FlowSynx.Client.Services;

public class HealthCheckService: IHealthCheckService
{
    private readonly IHttpRequestService _httpRequestService;

    public HealthCheckService(IHttpRequestService httpRequestService) => _httpRequestService = httpRequestService;

    public async Task<HttpResult<HealthCheckResponse>> Check(
        CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request
        {
            HttpMethod = HttpMethod.Get,
            Uri = "health",
        };

        return await _httpRequestService
            .SendRequestAsync<HealthCheckResponse>(requestMessage, cancellationToken);
    }
}