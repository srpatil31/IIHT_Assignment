using System.ServiceProcess;

namespace WeatherServiceHost
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new WeatherService()
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
