using FlowSynx.Client;
using FlowSynx.Client.Requests.Storage;

namespace Client;

internal class StorageExample
{
    internal class StorageList : Example
    {
        public override string DisplayName => "Getting FlowSynx storage list";

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            using var client = new FlowSynxClientFactory().CreateClient();
            var request = new ListRequest { Path = @"C:\", Sorting = "kind asc" };
            var result = await client.List(request, cancellationToken);
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
                    Console.WriteLine($@"Id:           {item.Id}");
                    Console.WriteLine($@"Name:         {item.Name}");
                    Console.WriteLine($@"Kind:         {item.Kind}");
                    Console.WriteLine($@"Size:         {item.Size}");
                    Console.WriteLine($@"MimeType:     {item.MimeType}");
                    Console.WriteLine($@"ModifiedTime: {item.ModifiedTime}");
                    Console.WriteLine();
                }

                Console.WriteLine(@"------------");
                Console.WriteLine(@"Done!");
            }
        }
    }

    internal class About : Example
    {
        public override string DisplayName => "About a FlowSynx storage";

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            using var client = new FlowSynxClientFactory().CreateClient();
            var request = new AboutRequest() { Path = @"C:\", Full = true };
            var result = await client.About(request, cancellationToken);
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

                Console.WriteLine($@"Total: {result.Data.Total}");
                Console.WriteLine($@"Used:  {result.Data.Used}");
                Console.WriteLine($@"Free:  {result.Data.Free}");
                Console.WriteLine();
                Console.WriteLine(@"------------");
                Console.WriteLine(@"Done!");
            }
        }
    }
}