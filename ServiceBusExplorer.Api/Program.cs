using System;
using System.Configuration;
using Microsoft.Owin.Hosting;
using ServiceBusExplorer.Api.Infrastructure;

namespace ServiceBusExplorer.Api
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var baseUri = ConfigurationManager.AppSettings.Get("baseUri");

            Logging.Initialize(new AppName(typeof(Startup).Assembly));
            
            Console.WriteLine("Starting web Server...");
            WebApp.Start<Startup>(baseUri);
            Console.WriteLine($"Server running at {baseUri} - press Enter to quit. ");
            Console.ReadLine();

            HubTicker.Stop();
            Logging.CloseAndFlush(new AppName(typeof(Startup).Assembly));
        }
    }
}
