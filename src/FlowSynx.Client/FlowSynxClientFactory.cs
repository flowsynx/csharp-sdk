namespace FlowSynx.Client;

public class FlowSynxClientFactory
{
    public IFlowSynxClient CreateClient()
    {
        return new FlowSynxClient();
    }
}