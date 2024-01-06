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

            app.MapGet("/version", async ([FromServices] IFlowSynxClient client) => await client.Version());

            app.Run();
        }
    }
}
