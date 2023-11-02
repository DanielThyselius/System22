using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestabilityDemo
{
    public class PrintReceipt
    {
        public string Execute(string item, float quantity)
        {
            var db = new Database();
            var now = DateTime.Now;
            var discount = (now.DayOfWeek == DayOfWeek.Friday) ? 25f : 0f;
            var price = db.GetItemPrice(item);

            var total = price * quantity * (1 - (discount / 100));

            return $"""
                   ********************************
                   KVITTO
                   {item}({price}) x {quantity}
                   rabatt: {discount}%
                   Total price: {total}:-
                   ~~~~~~~~~~~~~~~~~~~~~ 
                   {now}
                   ********************************
                   """;

        }

        public float GetQuantityFromUser()
        {
            Console.WriteLine("Hur många?");
            var quantity = float.Parse(Console.ReadLine());
            return quantity;
        }

        public string GetItemFromUser()
        {
            Console.WriteLine("Vad vill du köpa?");
            var item = Console.ReadLine();
            return item;
        }
    }
}
