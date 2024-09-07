﻿using FlowSynx.Client;
using FlowSynx.Client.Requests.Plugins;

namespace Client.Examples;

internal class PluginsList : Example
{
    public override string DisplayName => "Getting FlowSynx Plugins";

    public override async Task RunAsync(CancellationToken cancellationToken)
    {
        using var client = new FlowSynxClientFactory().CreateClient();
        var request = new PluginsListRequest() { };
        var result = await client.PluginsList(request, cancellationToken);
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
                Console.WriteLine($@"Id:          {item.Id}");
                Console.WriteLine($@"Type:        {item.Type}");
                Console.WriteLine($@"Description: {item.Description}");
                Console.WriteLine();
            }

            Console.WriteLine(@"------------");
            Console.WriteLine(@"Done!");
        }
    }
}