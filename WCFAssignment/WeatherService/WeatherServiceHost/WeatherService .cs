using System;
using System.ServiceModel;
using System.ServiceProcess;

namespace WeatherServiceHost
{
    public partial class WeatherService : ServiceBase
    {
        ServiceHost host;

        public WeatherService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            if (host != null)
            {
                host.Close();
            }
            host = new ServiceHost(typeof(WeatherServiceLib.WeatherService));
            host.Open();
            Console.WriteLine("Service Hosted Sucessfully");
        }

        protected override void OnStop()
        {
            if (host != null)
            {
                host.Close();
                host = null;
            }
        }
    }
}