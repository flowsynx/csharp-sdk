using FlowSynx.Client;
using FlowSynx.Client.Authentication;

namespace Client.Examples;

internal class PluginConfigList : Example
{
    private readonly IFlowSynxClient _flowSynxClient;

    public PluginConfigList(IFlowSynxClient flowSynxClient)
    {
        _flowSynxClient = flowSynxClient;
    }

    public override string DisplayName => "Getting FlowSynx Config";

    public override async Task RunAsync(CancellationToken cancellationToken)
    {
        var result = await _flowSynxClient.PluginConfig.ListAsync( cancellationToken);
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
                Console.WriteLine(item.Name);
                Console.WriteLine();
            }

            Console.WriteLine(@"------------");
            Console.WriteLine(@"Done!");
        }
    }
}