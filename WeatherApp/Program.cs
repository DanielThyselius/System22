
using WeatherApp;

var weatherService = new WeatherService();


Console.WriteLine("Vilken stad vill du ha väder för?");
var city = Console.ReadLine();
var weather = weatherService.GetWeather(city);


Console.WriteLine($"Today is {DateTime.Now.DayOfWeek}");
Console.WriteLine($"The weather in {city} is {weather}");

