using CleanStrike.Core.Engine;
using CleanStrike.Core.Settings;
using CleanStrike.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace CleanStrike
{
    class Program
    {
        static void Main(string[] args)
        {
            // create service collection
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            //create service provider
            var serviceProvider = serviceCollection.BuildServiceProvider();

            //run app
            serviceProvider.GetService<CleanStrikeApp>().Run();
        }

        private static void ConfigureServices(ServiceCollection serviceCollection)
        {

            serviceCollection.AddLogging();
            // build configuration
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("clearstrike-settings.json", false)
                .Build();

            serviceCollection.AddOptions();
            serviceCollection.RegisterApplicationDependencies();
            serviceCollection.Configure<ApplicationSettings>(options=>configuration.GetSection("Configuration"));
            ConfigureConsole(configuration);
           
            // add app
            serviceCollection.AddTransient<CleanStrikeApp>();
        }
        private static void ConfigureConsole(IConfigurationRoot configuration)
        {
            System.Console.Title = configuration.GetSection("Configuration:ConsoleTitle").Value;
        }
    }
}
