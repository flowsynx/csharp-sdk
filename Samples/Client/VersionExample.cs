using FlowSynx.Client;
using FlowSynx.Client.Requests.Config;

namespace Client;

internal class VersionExample: Example
{
    public override string DisplayName => "Using FlowSynx Version";

    public override async Task RunAsync(CancellationToken cancellationToken)
    {
        using var client = new FlowSynxClientFactory().CreateClient();
        var result = await client.Version(cancellationToken);
        if (!result.Succeeded)
        {
            Console.WriteLine(@"The operation is not successes");
            Console.WriteLine(result.Messages);
        }
        else
        {
            Console.WriteLine($@"FlowSynx:       {result.Data.FlowSynx}");
            Console.WriteLine($@"OSVersion:      {result.Data.OSVersion}");
            Console.WriteLine($@"OSArchitecture: {result.Data.OSArchitecture}");
            Console.WriteLine($@"OSType:         {result.Data.OSType}");
            Console.WriteLine(@"------------");
            Console.WriteLine(@"Done!");
        }
    }
}