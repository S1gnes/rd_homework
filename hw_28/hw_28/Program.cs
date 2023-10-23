using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        int numThreads = Environment.ProcessorCount; 

        if (args.Length > 0)
        {
            if (int.TryParse(args[0], out int userThreads))
            {
                numThreads = userThreads;
            }
            else
            {
                Console.WriteLine("Invalid input for thread count. Using default value.");
            }
        }

        Console.WriteLine($"Using {numThreads} thread(s).");

        int[] numbers = Enumerable.Range(1, 100000000).ToArray();

        Console.WriteLine("Processing data using PLINQ...");

        var stopwatch = new Stopwatch();
        stopwatch.Start();

        var result = numbers.AsParallel()
                            .WithDegreeOfParallelism(numThreads)
                            .Where(x => x % 2 == 0)
                            .Select(x => x * x)
                            .ToList();

        stopwatch.Stop();

        Console.WriteLine($"Result: {result.Count}");
        Console.WriteLine($"Time elapsed: {stopwatch.ElapsedMilliseconds} ms");
    }
}
