using FlowSynx.Client.Http;
using FlowSynx.Client.Messages.Responses;
using FlowSynx.Client.Messages.Responses.Audits;
using FlowSynx.Client.Messages.Requests;

namespace FlowSynx.Client.Services;

public class AuditService: IAuditService
{
    private readonly IHttpRequestHandler _httpRequestHandler;

    public AuditService(IHttpRequestHandler httpRequestHandler) => _httpRequestHandler = httpRequestHandler;

    public async Task<HttpResult<Result<IEnumerable<AuditsListResponse>>>> ListAsync(
        CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request
        {
            HttpMethod = HttpMethod.Get,
            Uri = "audits"
        };

        return await _httpRequestHandler
            .SendRequestAsync<Result<IEnumerable<AuditsListResponse>>>(requestMessage, cancellationToken);
    }
}