
// This is NOT how you should be coding!

using TestabilityDemo;

var printReceipt = new PrintReceipt();
var item = printReceipt.GetItemFromUser();
var quantity = printReceipt.GetQuantityFromUser();

var receipt = printReceipt.Execute(item, quantity);
Console.WriteLine(receipt);

public class Database
{
    // Let's pretend this actually connects to a database
    public float GetItemPrice(string id) => new Random().Next(1, 10);
}
