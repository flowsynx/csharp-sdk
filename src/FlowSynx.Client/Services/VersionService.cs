using FlowSynx.Client.Http;
using FlowSynx.Client.Messages.Responses;
using FlowSynx.Client.Messages.Requests;
using FlowSynx.Client.Messages.Responses.Version;

namespace FlowSynx.Client.Services;

public class VersionService: IVersionService
{
    private readonly IHttpRequestHandler _httpRequestHandler;

    public VersionService(IHttpRequestHandler httpRequestHandler) => _httpRequestHandler = httpRequestHandler;

    public async Task<HttpResult<Result<VersionResponse>>> GetVersion(
        CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request
        {
            HttpMethod = HttpMethod.Get,
            Uri = "version"
        };

        return await _httpRequestHandler
            .SendRequestAsync<Result<VersionResponse>>(requestMessage, cancellationToken);
    }
}