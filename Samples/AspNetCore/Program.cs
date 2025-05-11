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
            builder.Services.AddFlowSynxClient(opt =>
            {
                opt.AuthenticationType = AuthenticationType.Basic;
                opt.Username = "admin";
                opt.Password = "admin";
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapGet("/health", async ([FromServices] IFlowSynxClient client, CancellationToken cancellationToken) =>
                await client.HealthCheck.Check(cancellationToken));

            app.MapGet("/version", async ([FromServices] IFlowSynxClient client, CancellationToken cancellationToken) =>
                await client.Version.GetVersion(cancellationToken));

            app.MapGet("/plugins", async ([FromServices] IFlowSynxClient client, CancellationToken cancellationToken) =>
                await client.Plugins.ListAsync(cancellationToken));

            app.Run();
        }
    }
}
