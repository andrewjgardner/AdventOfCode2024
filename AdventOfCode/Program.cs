using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using AdventOfCode.Interfaces;
using AdventOfCode.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;


namespace AdventOfCode
{
    internal class Program
    {
       
        static Task Main(string[] args)
        {
            var httpClient = new HttpClient();
            var host = Host.CreateApplicationBuilder(args);
            host.Services.TryAddSingleton<IConfigService, ConfigService>();
            host.Services.TryAddSingleton<IAdventApiService, AdventApiService>();
            

            /*
            var builder = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json", true, true);

            var config = builder.Build();
            */
            
            // CreateAppDataSubDirectory(config["ConfigDir"]);
            return Task.CompletedTask;
        }

        private static bool CreateAppDataSubDirectory(string? name)
        {
            var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var appDirectory = Path.Combine(appDataPath, name);
            if (Directory.Exists(appDirectory)) return false;
            Directory.CreateDirectory(appDirectory);
            Console.WriteLine($"Created directory: {appDirectory}");
            return true;

        }

        private static async Task RetrieveTestInput()
        {

        }

    }

}