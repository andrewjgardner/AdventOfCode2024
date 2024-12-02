﻿using System;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;

namespace AdventOfCode
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            using HttpClient client = new HttpClient();
            var url = ConfigurationManager.AppSettings["adventOfCodeURL"];
            url += "1/input";

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


    }
}