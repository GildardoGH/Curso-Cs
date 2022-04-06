using System.Diagnostics;

//Console.WriteLine("Loading...");
//Asynchronous.WaitForIt();
//Console.WriteLine("Loaded");
//await Asynchronous.WaitForIt2();


var timeElapsed = await Parallelism.Main();
Console.WriteLine($"Both process finished after: {timeElapsed / 1000m} seconds");

public class Asynchronous
{
    public static async Task WaitForIt()
    {
        await Task.Delay(TimeSpan.FromSeconds(5));
        Console.WriteLine("Five seconds complete");
    }

    public static async Task WaitForIt2()
    {
        await Task.Delay(TimeSpan.FromSeconds(10));
        Console.WriteLine("Ten seconds complete");
    }
}

public class Parallelism
{
    public static async Task<long> Main()
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();

        await Process1();
        var task2 = await Process2();

       // await Task.WhenAll(task1, task2);

        stopwatch.Stop();

        return stopwatch.ElapsedMilliseconds;
    }
    public static async Task Process1()
    {
        await Task.Run(() =>
        {
            Thread.Sleep(4000);
        });
    }

    public static async Task<string> Process2()
    {
        return await Task.Run(() =>
        {
            Console.WriteLine("Start running second process...");
            Thread.Sleep(1000);
            return "Finished";
        }).ContinueWith((message) =>
        {
            return $"Status: {message}";
        });
    }
}