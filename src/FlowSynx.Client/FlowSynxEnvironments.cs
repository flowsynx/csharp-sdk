namespace FlowSynx.Client;

public class FlowSynxEnvironments
{
    private static string _httpEndpoint = string.Empty;
    
    public static string GetDefaultHttpEndpoint()
    {
        if (string.IsNullOrEmpty(_httpEndpoint))
        {
            _httpEndpoint = $"http://localhost:{6262}";
        }

        return _httpEndpoint;
    }
}