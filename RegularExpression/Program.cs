using System.Text.RegularExpressions;

var domain = "https://www.something.com";
var phoneNumber = "+52(686)123-45-67";


static void DomainValidation(string domain)
{
    Regex regex = new Regex(@"https?://(www.)?([\w\-]+)((\.(\w){2,3})+)$");
    Console.WriteLine(regex.IsMatch(domain));
}

static void PhoneNumberValidation(string phoneNumber)
{
    Regex regex = new Regex(@"+52");
    Console.WriteLine(regex.IsMatch(phoneNumber));
}
