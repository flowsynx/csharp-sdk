using FlowSynx.Client;
using FlowSynx.Client.Requests.Plugins;

namespace Client.Examples;

internal class PluginsDetails : Example
{
    public override string DisplayName => "Getting FlowSynx Plugin Detail";

    public override async Task RunAsync(CancellationToken cancellationToken)
    {
        using var client = new FlowSynxClientFactory().CreateClient();
        var request = new PluginDetailsRequest()
        {
            Type = "FlowSynx.Storage/LocalFileSystem"
        };
        var result = await client.PluginDetails(request, cancellationToken);
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