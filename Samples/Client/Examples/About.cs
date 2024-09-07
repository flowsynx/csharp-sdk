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
            Console.WriteLine(payload.Data);
            Console.WriteLine(@"Done!");
        }
    }
}