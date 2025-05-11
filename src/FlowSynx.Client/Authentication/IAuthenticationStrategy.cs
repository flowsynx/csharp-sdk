namespace FlowSynx.Client.Authentication;

public interface IAuthenticationStrategy
{
    Task ApplyAsync(HttpRequestMessage request);
}