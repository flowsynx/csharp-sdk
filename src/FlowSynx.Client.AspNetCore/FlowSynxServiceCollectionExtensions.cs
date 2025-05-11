using FlowSynx.Client.Authentication;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace FlowSynx.Client.AspNetCore;

public static class FlowSynxServiceCollectionExtensions
{
    public static IServiceCollection AddFlowSynxClient(this IServiceCollection services, Action<FlowSynxClientOptions> configure)
    {
        if (services is null)
            throw new ArgumentNullException(nameof(services));
        if (configure is null)
            throw new ArgumentNullException(nameof(configure));

        if (services.Any(s => s.ServiceType == typeof(IFlowSynxClient)))
            return services;

        services.Configure(configure);

        services.AddScoped<IAuthenticationStrategy>(sp =>
        {
            var options = sp.GetRequiredService<IOptions<FlowSynxClientOptions>>().Value;

            return options.AuthenticationType switch
            {
                AuthenticationType.Basic => new BasicAuthenticationStrategy(options.Username!, options.Password!),
                AuthenticationType.BearerToken => new BearerTokenAuthStrategy(options.BearerToken!),
                _ => throw new InvalidOperationException("Unsupported or misconfigured authentication type.")
            };
        });

        services.AddScoped<IFlowSynxServiceFactory, FlowSynxServiceFactory>();

        services.AddScoped<IFlowSynxClientConnection>(sp =>
        {
            var options = sp.GetRequiredService<IOptions<FlowSynxClientOptions>>().Value;
            var baseUrl = string.IsNullOrEmpty(options.BaseUrl)
                ? FlowSynxEnvironments.GetDefaultHttpEndpoint()
                : options.BaseUrl;

            return new FlowSynxClientConnection(baseUrl);
        });

        services.AddHttpClient();

        services.AddScoped<IFlowSynxClient>(sp =>
        {
            var connection = sp.GetRequiredService<IFlowSynxClientConnection>();
            var authStrategy = sp.GetRequiredService<IAuthenticationStrategy>();
            var serviceFactory = sp.GetRequiredService<IFlowSynxServiceFactory>();

            return new FlowSynxClient(connection, authStrategy, serviceFactory);
        });

        return services;
    }
}