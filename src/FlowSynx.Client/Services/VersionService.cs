using FlowSynx.Client.Http;
using FlowSynx.Client.Messages.Responses;
using FlowSynx.Client.Messages.Requests;
using FlowSynx.Client.Messages.Responses.Version;

namespace FlowSynx.Client.Services;

public class VersionService: IVersionService
{
    private readonly IHttpRequestService _httpRequestService;

    public VersionService(IHttpRequestService httpRequestService) => _httpRequestService = httpRequestService;

    public async Task<HttpResult<Result<VersionResponse>>> GetVersion(
        CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request
        {
            HttpMethod = HttpMethod.Get,
            Uri = "version"
        };

        return await _httpRequestService
            .SendRequestAsync<Result<VersionResponse>>(requestMessage, cancellationToken);
    }
}