namespace FlowSynx.Client.Authentication;

public class BearerTokenAuthStrategy : IAuthenticationStrategy
{
    private readonly string _token;

    public BearerTokenAuthStrategy(string token) => _token = token;

    public Task ApplyAsync(HttpRequestMessage request)
    {
        request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _token);
        return Task.CompletedTask;
    }
}
