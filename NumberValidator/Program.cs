

using NumberValidator;

Console.WriteLine("Welcome to my amazing Number Validator!");
Console.WriteLine("What Type of number would you like to validate?");
Console.WriteLine("1) ISBN10");
Console.WriteLine("2) ISBN13");
Console.WriteLine("3) SSN (swedish)");
Console.WriteLine("4) Password");
var numberType = NumberType.Undefined;
var validator = new Validator();

do
{
    var key = Console.ReadKey(intercept: true).KeyChar;

    if (char.IsBetween(key, '1', '4'))
    {
        numberType = (NumberType)(key - '0');
        Console.WriteLine($"{numberType.ToString()} chosen.");
        break;
    }

    Console.WriteLine("\nInvalid input. Please enter a valid integer.");
} while (true);

Console.WriteLine("What's the number?");
Console.Write("s: ");
var s = Console.ReadLine() ?? "";

switch (numberType)
{
    case NumberType.Isbn10:
        {
            var valid = validator.IsValidIsbn10(s);
            Console.WriteLine($"'{s}' is {(valid ? "a valid" : "an invalid")} {NumberType.Isbn10.ToString()}!");
            break;
        }

    case NumberType.Isbn13:
        {
            var valid = validator.IsValidIsbn13(s);
            Console.WriteLine($"'{s}' is {(valid ? "a valid" : "an invalid")} {NumberType.Isbn13.ToString()}!");
            break;
        }

    case NumberType.Ssn:
        {
            var valid = validator.IsValidSsn(s);
            Console.WriteLine($"'{s}' is {(valid ? "a valid" : "an invalid")} {NumberType.Ssn.ToString()}!");
            break;
        }
    case NumberType.Password:
        {
            var valid = validator.IsValidPassword(s);
            Console.WriteLine($"'{s}' is {(valid ? "a valid" : "an invalid")} {NumberType.Password.ToString()}!");
            break;
        }
}


enum NumberType
{
    Undefined = 0,
    Isbn10,
    Isbn13,
    Ssn,
    Password,
}
