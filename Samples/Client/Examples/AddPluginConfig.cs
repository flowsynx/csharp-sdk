﻿using FlowSynx.Client;
using FlowSynx.Client.Messages.Requests.PluginConfig;

namespace Client.Examples;

internal class AddPluginConfig : Example
{
    private readonly IFlowSynxClient _flowSynxClient;

    public AddPluginConfig(IFlowSynxClient flowSynxClient)
    {
        _flowSynxClient = flowSynxClient;
    }

    public override string DisplayName => "Add FlowSynx Config";

    public override async Task RunAsync(CancellationToken cancellationToken)
    {
        var request = new AddPluginConfigRequest()
        {
            Name = "test",
            Type = "FlowSynx.Storage/LocalFileSystem",
            Version = "1.0.0",
            Specifications = new Dictionary<string, object?>()
            {
                {"accountName", "<NAME>"},
                {"accountKey", "<KEY>"}
            }
        };

        var result = await _flowSynxClient.PluginConfig.AddAsync(request, cancellationToken);
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