﻿using Client.Examples;

namespace Client
{
    internal class Program
    {
        private static readonly Example[] Examples = new Example[]
        {
            new ConfigList(),       // 0
            new ConfigAdd(),        // 1
            new ConnectorsList(),   // 2
            new ConnectorDetails(), // 3
            new Health(),           // 4
            new VersionExample(),   // 5
            new About(),            // 6
            new List(),             // 7
        };

        static async Task<int> Main(string[] args)
        {
            if (args.Length > 0 && int.TryParse(args[0], out var index) && index >= 0 && index < Examples.Length)
            {
                var cts = new CancellationTokenSource();
                Console.CancelKeyPress += (object? sender, ConsoleCancelEventArgs e) => cts.Cancel();

                await Examples[index].RunAsync(cts.Token);
                return 0;
            }

            Console.WriteLine(@"Hi, please select a sample to run:");
            for (var i = 0; i < Examples.Length; i++)
            {
                Console.WriteLine($@"{i}: {Examples[i].DisplayName}");
            }
            Console.WriteLine();
            return 1;
        }
    }
}
