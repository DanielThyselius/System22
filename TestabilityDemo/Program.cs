
// This is NOT how you should be coding!

using TestabilityDemo;

var db = new Database();
var dateTimeWrapper = new DateTimeWrapper();
var printReceipt = new PrintReceipt(db, dateTimeWrapper);
var item = printReceipt.GetItemFromUser();
var quantity = printReceipt.GetQuantityFromUser();


var receipt = printReceipt.GenerateReceiptString(item, quantity);
Console.WriteLine(receipt);


public interface IDatabase
{
    public float GetItemPrice(string s);
}

public class Database : IDatabase
{
    // Let's pretend this actually connects to a database
    public float GetItemPrice(string id) => new Random().Next(1, 10);
}

public class MockDatabase : IDatabase
{
    // we know what we get
    public float GetItemPrice(string id) => 2;
}

public interface IDateTimeWrapper
{
    DateTime GetNow();
}

public class DateTimeWrapper : IDateTimeWrapper
{
    public DateTime GetNow()
    {
        return DateTime.Now;
    }
}

public class MockDateTimeWrapper : IDateTimeWrapper
{
    private readonly DateTime _now;
    public MockDateTimeWrapper()
    {
        _now = new DateTime(2023, 11, 03, 13, 14, 00);
    }

    public MockDateTimeWrapper(bool isFriday)
    {
        if (isFriday)
        {
            _now = new DateTime(2023, 11, 03, 13, 14, 00);
        }
        else
        {
            _now = new DateTime(2023, 11, 02, 13, 14, 00);
        }
    }

    public DateTime GetNow()
    {
        return _now;
    }
}
