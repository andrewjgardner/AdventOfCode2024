using AdventOfCode.Interfaces;
using Microsoft.Extensions.Configuration;

namespace AdventOfCode.Services;

internal class ConfigService
    :IConfigService
{
    private readonly IConfigurationRoot? _config;
    public string GetConfigItem(string key) => _config?[key] ?? "";

    public ConfigService()
    {
        var builder = new ConfigurationBuilder()
            .AddJsonFile($"appsettings.json", true, true);

        _config = builder.Build();
            
    }
}