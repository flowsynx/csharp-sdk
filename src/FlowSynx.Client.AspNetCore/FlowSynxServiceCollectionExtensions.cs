using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace FlowSynx.Client.AspNetCore;

public static class FlowSynxServiceCollectionExtensions
{
    public static void AddFlowSynxClient(this IServiceCollection services)
    {
        if (services is null)
        {
            throw new ArgumentNullException(nameof(services));
        }

        // This pattern prevents registering services multiple times in the case AddFlowSynxClient is called
        // by non-user-code.
        if (services.Any(s => s.ImplementationType == typeof(IFlowSynxClient)))
            return;

        services.TryAddSingleton<IFlowSynxClient>(_ =>
        {
            var builder = new FlowSynxClientFactory();
            return builder.CreateClient();
        });
    }
}