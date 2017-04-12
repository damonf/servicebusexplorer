using System;
using System.Configuration;
using Microsoft.Owin.Hosting;
using ServiceBusExplorer.Api.Logging;

namespace ServiceBusExplorer.Api
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var baseUri = ConfigurationManager.AppSettings.Get("baseUri");

            Logger.Initialize(typeof(Startup).Assembly);

            Console.WriteLine("Starting web Server...");

            var startup = new Startup();

            using (WebApp.Start(baseUri, app => startup.Configuration(app)))
            {
                Console.WriteLine($"Server running at {baseUri} - press Enter to quit. ");
                Console.ReadLine();
                startup.BeforeShutdown();
            }

            Logger.CloseAndFlush(typeof(Startup).Assembly);
        }
    }
}
