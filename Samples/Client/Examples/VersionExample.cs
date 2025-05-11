using FlowSynx.Client;
using FlowSynx.Client.Authentication;

namespace Client.Examples;

internal class VersionExample : Example
{
    private readonly IFlowSynxClient _flowSynxClient;

    public VersionExample(IFlowSynxClient flowSynxClient)
    {
        _flowSynxClient = flowSynxClient;
    }

    public override string DisplayName => "Using FlowSynx Version";

    public override async Task RunAsync(CancellationToken cancellationToken)
    {
        var result = await _flowSynxClient.Version.GetVersion(cancellationToken);
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
            Console.WriteLine($@"Version:       {payload.Data.Version}");
            Console.WriteLine(@"------------");
            Console.WriteLine(@"Done!");
        }
    }
}