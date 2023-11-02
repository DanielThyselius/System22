using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestabilityDemo
{
    public class PrintReceipt
    {
        private readonly IDatabase db;
        private readonly IDateTimeWrapper _dateTimeWrapper;

        public PrintReceipt(IDatabase database, IDateTimeWrapper dateTimeWrapper)
        {
            db = database;
            _dateTimeWrapper = dateTimeWrapper;
        }

        public string Execute(string item, float quantity)
        {
            var now = _dateTimeWrapper.GetNow();

            var discount = (now.DayOfWeek == DayOfWeek.Friday) ? 25f : 0f;
            var price = db.GetItemPrice(item);
            float total = NewMethod(quantity, discount, price);

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

        private static float NewMethod(float quantity, float discount, float price)
        {
            return price * quantity * (1 - (discount / 100));
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
