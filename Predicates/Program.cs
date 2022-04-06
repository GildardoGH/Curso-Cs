//Declaramos delegado predicado
Predicate<int> predicate = new Predicate<int>(GetPrimeNumbers);

List<int> list = new List<int>();
list.AddRange(new int[] { 1,2,3,4,5,6,7,8,9 });

List<int> result = list.FindAll(predicate);
//List<int> result = LambdaExpresssion.GetPairs();  //Demostrarlo despues de explicar expresiones lambda

foreach (var item in result)
{
    Console.WriteLine(item);
}

static bool GetAll(int num)
{
    return true;
}

static bool GetPairs(int num)
{
    if (num % 2 == 0) return true;
    else return false;
}

static bool GetPrimeNumbers(int num)
{
    int counter = 0;

    for(int i = num ; i > 0; i--)
    {
        if (num % i == 0) 
            counter++;
    }

    if (counter == 2)
        return true;
    else
        return false;
}

class LambdaExpresssion
{
    private static List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    
    public static List<int> GetPairs()
    {
        return list.FindAll(x => x % 2 == 0);
    }
}