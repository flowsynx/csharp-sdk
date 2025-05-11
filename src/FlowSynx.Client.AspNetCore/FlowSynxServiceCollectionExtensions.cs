using FlowSynx.Client.Authentication;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace FlowSynx.Client.AspNetCore;

/// <summary>
/// Provides extension methods for configuring and adding FlowSynx-related services to the <see cref="IServiceCollection"/>.
/// </summary>
public static class FlowSynxServiceCollectionExtensions
{
    /// <summary>
    /// Adds the FlowSynx client and its dependencies to the <see cref="IServiceCollection"/>.
    /// Configures authentication strategy, client connection, and services needed for the FlowSynx client.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
    /// <param name="configure">The action to configure the <see cref="FlowSynxClientOptions"/> for FlowSynx client.</param>
    /// <returns>The updated <see cref="IServiceCollection"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="services"/> or <paramref name="configure"/> is null.</exception>
    /// <remarks>
    /// This method registers the <see cref="IFlowSynxClient"/> and its related dependencies, including:
    /// <list type="bullet">
    ///     <item><description>Authentication strategy</description></item>
    ///     <item><description>FlowSynx service factory</description></item>
    ///     <item><description>Client connection</description></item>
    ///     <item><description>HttpClient</description></item>
    /// </list>
    /// </remarks>
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