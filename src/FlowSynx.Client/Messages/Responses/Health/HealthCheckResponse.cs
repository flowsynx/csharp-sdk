namespace FlowSynx.Client.Messages.Responses.Health;

public class HealthCheckResponse
{
    public string? Status { get; set; }
    public IEnumerable<IndividualHealthCheckResponse> HealthChecks { get; set; } = new List<IndividualHealthCheckResponse>();
    public TimeSpan HealthCheckDuration { get; set; }
}

public class IndividualHealthCheckResponse
{
    public string? Status { get; set; }
    public string? Component { get; set; }
    public string? Description { get; set; }
}