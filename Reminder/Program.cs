using System.Text.RegularExpressions;

Console.WriteLine("What's your event name?");
var inputName = Console.ReadLine();
if (string.IsNullOrEmpty(inputName))
{
    Console.WriteLine("The event must have a name.");
    return;
}

Console.WriteLine("When will it start? Please indicate the date with the next format (mm/dd/yyyy)");
var inputDate = Console.ReadLine();
if (!CheckDateFormat(inputDate))
{
    Console.WriteLine("Please insert a valid date format.");
    return;
}
    
Console.WriteLine("Please indicate how many days before you want me start reminding you.");
var inputReminder = Console.ReadLine();
if (!Int32.TryParse(inputReminder, out int reminder))
{
    Console.WriteLine("Please insert an integer");
    return;
}

Console.WriteLine("Please indicate the current date.");
var inputToday = Console.ReadLine();
if (!CheckDateFormat(inputToday))
{
    Console.WriteLine("Please insert a valid date format.");
    return;
}

var eventDate = Convert.ToDateTime(inputDate);
var currentDate = Convert.ToDateTime(inputToday);

if(currentDate >= eventDate)
{
    Console.WriteLine("The current date can not be higher than the event date.");
    return;
}

Console.Clear();

var ev = new Event(inputName, eventDate, reminder);
currentDate = await ev.CatchReminder(currentDate);
await ev.CatchEvent(currentDate);

Console.Clear();
Console.WriteLine($"Hey, {ev.Name} is today!!!");

//while (!eventNow.IsCompleted)
//{
//    currentDate = currentDate.AddDays(1);
//    Console.WriteLine($"Only {ev.Date.Day - currentDate.Day} days to the event!");

//    await Task.Delay(1000);
//    Console.Clear();
//}

static bool CheckDateFormat(string date)
{
    Regex isMonthOrDay = new Regex(@"[\d{2}]");
    Regex isYear = new Regex(@"[\d{4}]");
    var dateArray = date.Split('/');

    if(!dateArray.Length.Equals(3))
        return false;

    if (!(isMonthOrDay.IsMatch(dateArray[0]) && isMonthOrDay.IsMatch(dateArray[1]) && isYear.IsMatch(dateArray[2])))
        return false;

    var month = Convert.ToInt32(dateArray[0]);
    var day = Convert.ToInt32(dateArray[1]);

    if (month > 0 && month <= 12 && day > 0 && day <= 31)
        return true;
    else
        return false;   
}

class Event
{
    public string Name { get; set; }
    public DateTime Date { get; set; }
    public DateTime Reminder { get; set; }

    public Event(string name, DateTime date, int reminder)
    {
        Name = name;
        Date = date;
        Reminder = date.AddDays(-reminder);
    }

    public async Task<DateTime> CatchReminder(DateTime now)
    {
        while(now < Reminder)
        {
            Console.WriteLine(now.ToString("MM/dd/yyyy"));
            await Task.Delay(TimeSpan.FromSeconds(1)); //Task.Delay(1000);
            now = now.AddDays(1);
            Console.Clear();
        }

        return now;
    }

    public async Task CatchEvent(DateTime now)
    {
        while (now < Date)
        {
            Console.WriteLine($"Only {Date.Day - now.Day} days to the event!");
            await Task.Delay(TimeSpan.FromSeconds(1)); //Task.Delay(1000);
            now = now.AddDays(1);
            Console.Clear();
        }
    }
}