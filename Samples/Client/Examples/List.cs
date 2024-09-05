using FlowSynx.Client;

namespace Client.Examples;

internal class List : Example
{
    public override string DisplayName => "Getting FlowSynx storage list";

    public override async Task RunAsync(CancellationToken cancellationToken)
    {
        using var client = new FlowSynxClientFactory().CreateClient();
        var request = new
        {
            entity = @"C:\",
            filters = new
            {
                limit = "10"
            }
        };
        var result = await client.InvokeMethod<object, object>(HttpMethod.Post, "list", request, cancellationToken);
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
            Console.WriteLine(result.Data);
            Console.WriteLine(@"Done!");
        }
    }
}