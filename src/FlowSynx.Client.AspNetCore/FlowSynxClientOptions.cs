using FlowSynx.Client.Authentication;

namespace FlowSynx.Client.AspNetCore;

public class FlowSynxClientOptions
{
    public string BaseUrl { get; set; } = default!;
    public AuthenticationType AuthenticationType { get; set; } = AuthenticationType.Basic;
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string? BearerToken { get; set; }
    public Func<IServiceProvider, IAuthenticationStrategy>? CustomAuthFactory { get; set; }
}