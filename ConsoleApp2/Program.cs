int[] result = new int[] { 2, 1, 5, 3, 4 };
GetBribes(result);

static void GetBribes(int[] result)
{
    for(var x = result.Length - 1; x >= 0; x--)
    {
        var pos = x + 1;

        if (result[x] > pos && pos + 2 < result[x])
        {
            Console.WriteLine("Too chaotic");
            return;
        }
    }

    var bribes = 0;

    for (var x = result.Length - 1; x >= 0; x--)
    {
        var pos = x + 1;

        if (x > 0 && result[x] <= pos && result[x - 1] >= pos)
        {
            var b = result[x];
            result[x] = result[x - 1];
            result[x - 1] = b;
            bribes++;

            if (x + 1 < result.Length)
                x += 2;
        }
    }

    Console.WriteLine(bribes);
}