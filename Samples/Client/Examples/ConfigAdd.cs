using FlowSynx.Client;
using FlowSynx.Client.Requests.Config;

namespace Client.Examples;

internal class ConfigAdd : Example
{
    public override string DisplayName => "Add FlowSynx Config";

    public override async Task RunAsync(CancellationToken cancellationToken)
    {
        using var client = new FlowSynxClientFactory().CreateClient();
        var request = new AddConfigRequest()
        {
            Name = "test",
            Type = "FlowSynx.Storage/LocalFileSystem",
            Specifications = new Dictionary<string, string?>()
            {
                {"accountName", "<NAME>"},
                {"accountKey", "<KEY>"}
            }
        };
        var result = await client.AddConfig(request, cancellationToken);
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
            foreach (var message in payload.Messages)
            {
                Console.WriteLine(message);
            }
            Console.WriteLine(@"------------");
            Console.WriteLine(@"Done!");
        }
    }
}