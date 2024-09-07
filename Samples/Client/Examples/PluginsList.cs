using FlowSynx.Client;
using FlowSynx.Client.Requests.Plugins;

namespace Client.Examples;

internal class PluginsList : Example
{
    public override string DisplayName => "Getting FlowSynx Plugins";

    public override async Task RunAsync(CancellationToken cancellationToken)
    {
        using var client = new FlowSynxClientFactory().CreateClient();
        var request = new PluginsListRequest() { };
        var result = await client.PluginsList(request, cancellationToken);
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
                Console.WriteLine($@"Id:          {item.Id}");
                Console.WriteLine($@"Type:        {item.Type}");
                Console.WriteLine($@"Description: {item.Description}");
                Console.WriteLine();
            }

            Console.WriteLine(@"------------");
            Console.WriteLine(@"Done!");
        }
    }
}