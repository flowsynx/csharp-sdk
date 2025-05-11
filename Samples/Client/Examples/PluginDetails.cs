using FlowSynx.Client;
using FlowSynx.Client.Messages.Requests.Plugins;

namespace Client.Examples;

internal class PluginDetails : Example
{
    private readonly IFlowSynxClient _flowSynxClient;

    public PluginDetails(IFlowSynxClient flowSynxClient)
    {
        _flowSynxClient = flowSynxClient;
    }

    public override string DisplayName => "Getting FlowSynx Connector Detail";

    public override async Task RunAsync(CancellationToken cancellationToken)
    {
        var request = new PluginDetailsRequest()
        {
            Id = Guid.Parse("62cf2f3b-4e98-48e4-acf9-5bc6ee9da2c9")
        };
        var result = await _flowSynxClient.Plugins.DetailsAsync(request, cancellationToken);
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
            Console.WriteLine($@"Id:          {payload.Data.Id}");
            Console.WriteLine($@"Type:        {payload.Data.Type}");
            Console.WriteLine($@"Description: {payload.Data.Description}");
            Console.WriteLine();
            Console.WriteLine(@"------------");
            Console.WriteLine(@"Done!");
        }
    }
}