Console.WriteLine("Loading...");
WaitForIt();
Console.WriteLine("Loaded");
await WaitForIt2();

async Task WaitForIt()
{
    await Task.Delay(TimeSpan.FromSeconds(5));
    Console.WriteLine("Five seconds complete");
}

async Task WaitForIt2()
{
    await Task.Delay(TimeSpan.FromSeconds(10));
    Console.WriteLine("Ten seconds complete");
}