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
        private readonly DateTime _now;

        public PrintReceipt(IDatabase database, IDateTimeWrapper dateTimeWrapper)
        {
            db = database;
            _now = dateTimeWrapper.GetNow();
        }


        public string GenerateReceiptString(string item, float quantity)
        {
            var discount = GetDiscount();
            var price = db.GetItemPrice(item);

            float total = Total(quantity, discount ,price);

            return $"""
                   ********************************
                   KVITTO
                   {item}({price}) x {quantity}
                   rabatt: {discount}%
                   Total price: {total}:-
                   ~~~~~~~~~~~~~~~~~~~~~ 
                   {_now}
                   ********************************
                   """;
        }

        public float GetDiscount()
        {
            return (_now.DayOfWeek == DayOfWeek.Friday) ? 25f : 0f;
        }

        public float Total(float quantity, float discount, float price)
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
