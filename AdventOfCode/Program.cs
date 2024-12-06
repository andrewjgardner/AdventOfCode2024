using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;


namespace AdventOfCode
{
    internal class Program
    {
       

        static async Task Main(string[] args)
        {
            configHelper = new ConfigHelper();

            CreateAppDataSubDirectory("AdventOfCode");


            url += "1/input";

            using HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "AdventOfCode2024 by github.com/andrewjgardner");
            client.DefaultRequestHeaders.Add("Cookie", config["Cookie"]);

            try
            {
                var response = await client.GetAsync(url);

                Console.Write(response);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private static bool CreateAppDataSubDirectory(string name)
        {
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string appDirectory = Path.Combine(appDataPath, name);
            if (!Directory.Exists(appDirectory))
            {
                Directory.CreateDirectory(appDirectory);
                Console.WriteLine($"Created directory: {appDirectory}");
                return true;
            }

            return false;
        }

        private static async Task RetrieveTestInput()
        {

        }

    }

}