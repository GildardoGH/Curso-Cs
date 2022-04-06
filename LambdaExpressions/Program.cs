Console.WriteLine("Please insert first number: ");
var first = Convert.ToDouble(Console.ReadLine());

Console.WriteLine("Please insert second number: ");
var second = Convert.ToDouble(Console.ReadLine());

//DelegateCalculator.Operate(Convert.ToDouble(first), Convert.ToDouble(second));

ActionCalculator.Lambda(Convert.ToDouble(first), Convert.ToDouble(second));

class DelegateCalculator
{
    public delegate double SelfOperator(double x);
    public delegate double Operator(double x, double y);

    public static void Operate(double first, double second)
    {
        SelfOperator square= new SelfOperator(x => x * x);
        Console.WriteLine(square(first));

        Operator sum = new Operator((x, y) =>  x + y);
        Console.WriteLine(sum(first, second));
    }
}

class FuncCalculator
{
    //Func<double, double, double> sum = (first, second) => first + second;
    //Console.WriteLine(sum(first, second));
}

class ActionCalculator
{
    public static void Lambda(double x, double y)
    {
        Action<double, double> addition = (x, y) =>
        {
            Console.WriteLine(x + y);
        };
        addition(x, y);
    }
}


