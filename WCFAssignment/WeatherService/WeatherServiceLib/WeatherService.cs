namespace WeatherServiceLib
{
    public class WeatherService : IWeatherService
    {
        public double CelciusToFarenheit(double temp)
        {
            return ((temp * 9) / 5 + 32);
        }

        public double FarenheitToCelcius(double temp)
        {
            return ((temp - 32) * 5 / 9);
        }
    }
}