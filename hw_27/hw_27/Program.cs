using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
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

        Task<int> task = CalculateAsync(10);

        Console.WriteLine("Task started");

        var stopwatch = new System.Diagnostics.Stopwatch();
        stopwatch.Start();

        int result = await task;

        stopwatch.Stop();

        Console.WriteLine("Result: " + result);
        Console.WriteLine($"Time elapsed: {stopwatch.ElapsedMilliseconds} ms");
    }

    static async Task<int> CalculateAsync(int number)
    {
        await Task.Delay(1000); 
        return number * number;
    }
}
