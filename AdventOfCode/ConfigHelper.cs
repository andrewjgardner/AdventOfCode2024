using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    internal class ConfigHelper
    {
        private static readonly IConfigurationRoot? config;
        public string GetConfigItem(string key) => config?[key] ?? "";

        public ConfigHelper()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json", true, true);

            var config = builder.Build();
        }
    }
}
