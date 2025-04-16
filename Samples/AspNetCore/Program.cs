using FlowSynx.Client;
using FlowSynx.Client.AspNetCore;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();
            builder.Services.AddFlowSynxClient();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapGet("/health", async ([FromServices] IFlowSynxClient client, CancellationToken cancellationToken) =>
                await client.Health(cancellationToken));

            app.MapGet("/version", async ([FromServices] IFlowSynxClient client, CancellationToken cancellationToken) =>
                await client.Version(cancellationToken));

            app.MapGet("/connectors", async ([FromServices] IFlowSynxClient client, CancellationToken cancellationToken) =>
                await client.PluginsList(cancellationToken));

            app.Run();
        }
    }
}
