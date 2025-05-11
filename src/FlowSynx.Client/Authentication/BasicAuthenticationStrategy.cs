using System.Net.Http.Headers;
using System.Text;

namespace FlowSynx.Client.Authentication;

public class BasicAuthenticationStrategy: IAuthenticationStrategy
{
    private readonly string _username;
    private readonly string _password;

    public BasicAuthenticationStrategy(string username, string password)
    {
        _username = username;
        _password = password;
    }

    public Task ApplyAsync(HttpRequestMessage request)
    {
        var credentials = Encoding.UTF8.GetBytes($"{_username}:{_password}");
        var base64Credentials = Convert.ToBase64String(credentials);

        request.Headers.Authorization = new AuthenticationHeaderValue("Basic", base64Credentials);
        return Task.CompletedTask;
    }
}
