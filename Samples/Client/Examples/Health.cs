using FlowSynx.Client;

namespace Client.Examples;

internal class Health : Example
{
    public override string DisplayName => "Checking FlowSynx Health";

    public override async Task RunAsync(CancellationToken cancellationToken)
    {
        using var client = new FlowSynxClientFactory().CreateClient();
        var result = await client.Health(cancellationToken);

        Console.WriteLine($@"Status:       {result.Status}");
        Console.WriteLine(@"------------");
        foreach (var item in result.HealthChecks)
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