using FlowSynx.Client;
using FlowSynx.Client.Requests.Config;

namespace Client.Examples;

internal class ConfigList : Example
{
    public override string DisplayName => "Getting FlowSynx Config";

    public override async Task RunAsync(CancellationToken cancellationToken)
    {
        using var client = new FlowSynxClientFactory().CreateClient();
        var request = new ConfigListRequest { };
        var result = await client.ConfigList(request, cancellationToken);
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
            foreach (var item in result.Data)
            {
                Console.WriteLine($@"Id:   {item.Id}");
                Console.WriteLine($@"Name: {item.Name}");
                Console.WriteLine($@"Type: {item.Type}");
                Console.WriteLine($@"ModifiedTime: {item.ModifiedTime}");
                Console.WriteLine();
            }

            Console.WriteLine(@"------------");
            Console.WriteLine(@"Done!");
        }
    }
}