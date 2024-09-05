using FlowSynx.Client;

namespace Client.Examples;

internal class About : Example
{
    public override string DisplayName => "About a FlowSynx storage";

    public override async Task RunAsync(CancellationToken cancellationToken)
    {
        using var client = new FlowSynxClientFactory().CreateClient();
        var request = new
        {
            entity = @"C:\",
            filters = new
            {
                full = false
            }
        };
        var result = await client.InvokeMethod<object, object>("about", request, cancellationToken);
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