namespace FlowSynx.Client;

internal class FlowSynxEnvironments
{
    private static string _httpEndpoint = string.Empty;
    
    public static string GetDefaultHttpEndpoint()
    {
        if (string.IsNullOrEmpty(_httpEndpoint))
        {
            var port = Environment.GetEnvironmentVariable("FLOWSYNX_HTTP_PORT");
            port = string.IsNullOrEmpty(port) ? "5860" : port;
            _httpEndpoint = $"http://127.0.0.1:{port}";
        }

        return _httpEndpoint;
    }
}