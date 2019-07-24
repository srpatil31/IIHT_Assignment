using System.ServiceModel;

namespace WeatherServiceLib
{
    [ServiceContract]
    public interface IWeatherService
    {
        [OperationContract]
        double CelciusToFarenheit(double temp);

        [OperationContract]
        double FarenheitToCelcius(double temp);
    }
}