Console.WriteLine("Search: ");
var input = Console.ReadLine();

Searcher(input);


static void Searcher(string input)
{
    User.Input = input;

    Predicate<Person> predicate = new Predicate<Person>(Person.Exists);
    Predicate<Person> predicate2 = new Predicate<Person>(Person.GetByAge);
    Predicate<Person> predicate3 = new Predicate<Person>(Person.GetByDate);

    List<Person> people = new List<Person>()
    {
    new Person() { Name = "Gildardo", Age = 27, Birthday = new DateTime(1995, 3, 25) },
    new Person() { Name = "Rene", Age = 34, Birthday = new DateTime(1991, 1, 25) }, 
    new Person() { Name = "Alejandra", Age = 31, Birthday = new DateTime(1995, 2, 25) }
    };

    if (User.Input.Contains(","))
    {
        var result = people.FindAll(predicate3);

        if (result.Any())
        {
            foreach (var person in result)
            {
                Console.WriteLine($"Name: {person.Name}\tDoB: {person.Birthday}\tAge: {person.Age}");
            }
        }
    }
    else if(Int32.TryParse(User.Input, out int age))
    {
        var result = people.FindAll(predicate2);

        if (result.Any())
        {
            foreach (var person in result)
            {
                Console.WriteLine($"Name: {person.Name}\tDoB: {person.Birthday}\tAge: {person.Age}");
            }
        }
    }
    else
    {
        if (people.Exists(predicate))
        {
            Console.WriteLine("The person exists in the database.");
        }
    }
}

class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public DateTime Birthday { get; set; }

    public static bool Exists(Person person)
    {
        if(person.Name.Equals(User.Input))
            return true;
        else
            return false;
    }

    public static bool GetByAge(Person person)
    {
        var age = Convert.ToInt32(User.Input);

        if (person.Age.Equals(age))
            return true;
        else
            return false;
    }

    public static bool GetByDate(Person person)
    {
        var startDate = DateTime.Parse(User.Input.Split(",")[0]);
        var endDate = DateTime.Parse(User.Input.Split(",")[1]);

        if (startDate < person.Birthday && endDate > person.Birthday)
            return true;
        else
            return false;
    }
}

class User
{
    public static string Input { get; set; }
}
