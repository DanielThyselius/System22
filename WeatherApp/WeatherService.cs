using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp
{
    public class WeatherService
    {
        public string GetWeather(string city)
        {
            string[] weatherStrings = { 
                "Sunny all day long", 
                "Raining cat and dogs",
                "Unclear",
                "Good day for eating apples",
                "Windy",
                "Local snowstorms"
            };
            var rand = new Random();
            var index = rand.Next(weatherStrings.Length);

            return weatherStrings[index];
        }
    }
}
