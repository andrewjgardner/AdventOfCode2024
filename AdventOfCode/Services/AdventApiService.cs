using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using AdventOfCode.Interfaces;

namespace AdventOfCode.Services;

public class AdventApiService : IAdventApiService
{

    private HttpClient _client;
    private readonly IConfigService _configService;

    public AdventApiService(IConfigService configService, HttpClient client)
    {
        _client = client;
        _configService = configService;

        _client.DefaultRequestHeaders.Add("User-Agent", _configService.GetConfigItem("UserAgentText"));
        _client.DefaultRequestHeaders.Add("Cookie", _configService.GetConfigItem("Cookie"));
    }

    public async Task<string> RetrieveTestInputByDay(int day)
    {
        string output;
        
        var url = GetTestDataUrl(day); 
        try
        {
            var response = await _client.GetAsync(url);
            if (response.IsSuccessStatusCode == false)
            {
                throw new InvalidOperationException($"URL: {url} returned status code: {response.StatusCode}");
            }
            output = await response.Content.ReadAsStringAsync();
        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
            throw;
        }

        return output;
    }


    private string GetTestDataUrl(int day)
    {
        return $"{_configService.GetConfigItem("AdventOfCodeURL")}/{day}/input";
    }
}