namespace FlowSynx.Client;

public static class FlowSynxClientFactory
{
    public static IFlowSynxClient CreateClient()
    {
        return new FlowSynxClient();
    }
}