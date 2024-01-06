using FlowSynx.Client;
using FlowSynx.Client.Requests.Storage;

namespace Client;

internal class StorageListExample: Example
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
            Console.WriteLine(result.Messages);
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