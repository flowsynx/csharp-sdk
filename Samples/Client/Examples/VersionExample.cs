﻿using FlowSynx.Client;

namespace Client.Examples;

internal class VersionExample : Example
{
    public override string DisplayName => "Using FlowSynx Version";

    public override async Task RunAsync(CancellationToken cancellationToken)
    {
        using var client = new FlowSynxClientFactory().CreateClient();
        var result = await client.Version(cancellationToken);
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