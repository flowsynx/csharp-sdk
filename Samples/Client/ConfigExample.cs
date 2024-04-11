using FlowSynx.Client;
using FlowSynx.Client.Requests.Config;

namespace Client;

internal class ConfigExample
{
    internal class ConfigList : Example
    {
        public override string DisplayName => "Getting FlowSynx Config";

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            using var client = new FlowSynxClientFactory().CreateClient();
            var request = new ConfigListRequest { };
            var result = await client.ConfigList(request, cancellationToken);
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
                    Console.WriteLine($@"Id:   {item.Id}");
                    Console.WriteLine($@"Name: {item.Name}");
                    Console.WriteLine($@"Type: {item.Type}");
                    Console.WriteLine();
                }

                Console.WriteLine(@"------------");
                Console.WriteLine(@"Done!");
            }
        }
    }

    internal class AddConfig : Example
    {
        public override string DisplayName => "Add FlowSynx Config";

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            using var client = new FlowSynxClientFactory().CreateClient();
            var request = new AddConfigRequest()
            {
                Name = "test",
                Type = "FlowSynx.Storage/LocalFileSystem",
                Specifications = new Dictionary<string, object?>()
                {
                    {"accountName", "<NAME>"},
                    {"accountKey", "<KEY>"}
                }
            };
            var result = await client.AddConfig(request, cancellationToken);
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
                foreach (var message in result.Messages)
                {
                    Console.WriteLine(message);
                }
                Console.WriteLine(@"------------");
                Console.WriteLine(@"Done!");
            }
        }
    }
}