using FlowSynx.Client;
using FlowSynx.Client.AspNetCore;
using FlowSynx.Client.Requests.Plugins;
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

            app.MapGet("/about", async ([FromServices] IFlowSynxClient client, CancellationToken cancellationToken) =>
                await client.InvokeMethod<object, object>("about", new
                {
                    entity = @"C:\",
                    filters = new
                    {
                        full = true
                    }
                }, cancellationToken));

            app.MapGet("/list", async ([FromServices] IFlowSynxClient client, CancellationToken cancellationToken) =>
                await client.InvokeMethod<object, object>("list", new
                {
                    entity = @"C:\",
                    filters = new
                    {
                        limit = "10"
                    }
                }, cancellationToken));

            app.MapGet("/plugins", async ([FromServices] IFlowSynxClient client, CancellationToken cancellationToken) =>
                await client.PluginsList(new PluginsListRequest(), cancellationToken));

            app.Run();
        }
    }
}
