using FlowSynx.Client;
using FlowSynx.Client.Authentication;

namespace Client.Examples;

internal class PluginsList : Example
{
    private readonly IFlowSynxClient _flowSynxClient;

    public PluginsList(IFlowSynxClient flowSynxClient)
    {
        _flowSynxClient = flowSynxClient;
    }

    public override string DisplayName => "Getting FlowSynx Connectors";

    public override async Task RunAsync(CancellationToken cancellationToken)
    {
        var result = await _flowSynxClient.Plugins.ListAsync(cancellationToken);
        if (result.StatusCode != 200)
        {
            Console.WriteLine(@"The status code is not 200, that means the operation was not successful.");
            return;
        }

        var payload = result.Payload;
        if (!payload.Succeeded)
        {
            Console.WriteLine(@"The operation is not successes");
            foreach (var message in payload.Messages)
            {
                Console.WriteLine(message);
            }
        }
        else
        {
            foreach (var item in payload.Data)
            {
                Console.WriteLine(item.Type);
            }

            Console.WriteLine(@"------------");
            Console.WriteLine(@"Done!");
        }
    }
}