using FlowSynx.Client.Http;
using FlowSynx.Client.Messages.Responses;
using FlowSynx.Client.Messages.Responses.Audits;
using FlowSynx.Client.Messages.Requests;
using FlowSynx.Client.Messages.Requests.Audits;

namespace FlowSynx.Client.Services;

public class AuditService : IAuditService
{
    private readonly IHttpRequestHandler _httpRequestHandler;

    /// <summary>
    /// Initializes a new instance of the <see cref="AuditService"/> class with the specified HTTP request handler.
    /// </summary>
    /// <param name="httpRequestHandler">The HTTP request handler used to send API requests.</param>
    public AuditService(IHttpRequestHandler httpRequestHandler) =>
        _httpRequestHandler = httpRequestHandler;

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

    public async Task<HttpResult<Result<AuditDetailsResponse>>> DetailsAsync(
        AuditDetailsRequest request,
        CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request
        {
            HttpMethod = HttpMethod.Get,
            Uri = $"audits/{request.Id}"
        };

        return await _httpRequestHandler
            .SendRequestAsync<Result<AuditDetailsResponse>>(requestMessage, cancellationToken);
    }
}
