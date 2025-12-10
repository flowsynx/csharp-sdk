using Client;
using Client.Examples;
using FlowSynx.Client;
using FlowSynx.Client.Authentication;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

IAuthenticationStrategy authStrategy = new BasicAuthenticationStrategy("admin", "admin");

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
    {
        services.AddHttpClient();
        services.AddSingleton<IFlowSynxServiceFactory, FlowSynxServiceFactory>();
        services.AddSingleton(authStrategy);
        services.AddSingleton<IFlowSynxClient, FlowSynxClient>();
        services.AddScoped<IFlowSynxClientConnection>(sp =>
        {
            var baseUrl = FlowSynxEnvironments.GetDefaultHttpEndpoint();
            return new FlowSynxClientConnection(baseUrl);
        });
    })
    .Build();

var client = host.Services.GetRequiredService<IFlowSynxClient>();

Example[] Examples = new Example[]
{
    new PluginsList(client),          // 2
    new PluginDetails(client),        // 3
    new Health(client),               // 4
    new VersionExample(client),       // 5
};

if (args.Length > 0 && int.TryParse(args[0], out var index) && index >= 0 && index < Examples.Length)
{
    var cts = new CancellationTokenSource();
    Console.CancelKeyPress += (object? sender, ConsoleCancelEventArgs e) => cts.Cancel();

    await Examples[index].RunAsync(cts.Token);
    return 0;
}

Console.WriteLine(@"Hi, please select a sample to run:");
for (var i = 0; i < Examples.Length; i++)
{
    Console.WriteLine($@"{i}: {Examples[i].DisplayName}");
}
Console.WriteLine();
return 1;
