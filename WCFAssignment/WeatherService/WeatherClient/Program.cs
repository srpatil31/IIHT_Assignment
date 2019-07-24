using System;

namespace WeatherClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceReference1.WeatherServiceClient client = new ServiceReference1.WeatherServiceClient("BasicHttpBinding_IWeatherService");
            Console.Write("Enter temperature in farenhe : ");
            double far = Convert.ToDouble(Console.Read());
            Console.WriteLine("Farenheit to Celcius : {0}", client.FarenheitToCelcius(far));

            Console.Write("Enter temperature in celcius : ");
            double cel = Convert.ToDouble(Console.Read());
            Console.WriteLine("Celcius to Farenheit : {0}", client.CelciusToFarenheit(cel));

            Console.Read();
        }
    }
}