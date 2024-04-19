namespace FlowSynx.Client;

public class FlowSynxClientFactory
{
    public IFlowSynxClient CreateClient()
    {
        return CreateClient(FlowSynxEnvironments.GetDefaultHttpEndpoint());
    }

    public IFlowSynxClient CreateClient(string address)
    {
        return new FlowSynxClient(new FlowSynxClientConnection
        {
            BaseAddress = address
        });
    }
}