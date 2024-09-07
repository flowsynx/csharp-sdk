using FlowSynx.Client;

namespace Client.Examples;

internal class Health : Example
{
    public override string DisplayName => "Checking FlowSynx Health";

    public override async Task RunAsync(CancellationToken cancellationToken)
    {
        using var client = new FlowSynxClientFactory().CreateClient();
        var result = await client.Health(cancellationToken);
        if (result.StatusCode != 200)
        {
            Console.WriteLine(@"The status code is not 200, that means the operation was not successful.");
            return;
        }

        var payload = result.Payload;
        Console.WriteLine($@"Status:       {payload.Status}");
        Console.WriteLine(@"------------");
        foreach (var item in payload.HealthChecks)
        {
            Console.WriteLine($@"Status:      {item.Status}");
            Console.WriteLine($@"Component:   {item.Component}");
            Console.WriteLine($@"Description: {item.Description}");
            Console.WriteLine();
        }
        Console.WriteLine(@"------------");
        Console.WriteLine(@"Done!");

    }
}