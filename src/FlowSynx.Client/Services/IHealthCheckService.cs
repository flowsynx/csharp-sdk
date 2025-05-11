using FlowSynx.Client.Messages.Responses.Health;
using FlowSynx.Client.Messages.Responses;

namespace FlowSynx.Client.Services;

public interface IHealthCheckService
{
    Task<HttpResult<HealthCheckResponse>> Check(
        CancellationToken cancellationToken = default);
}