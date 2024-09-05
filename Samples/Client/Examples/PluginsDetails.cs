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
        if (!result.Succeeded)
        {
            Console.WriteLine(@"The operation is not successes");
            foreach (var message in result.Messages)
            {
                Console.WriteLine(message);
            }
        }
        else
        {
            Console.WriteLine($@"Id:          {result.Data.Id}");
            Console.WriteLine($@"Type:        {result.Data.Type}");
            Console.WriteLine($@"Description: {result.Data.Description}");
            Console.WriteLine();
            Console.WriteLine(@"------------");
            Console.WriteLine(@"Done!");
        }
    }
}