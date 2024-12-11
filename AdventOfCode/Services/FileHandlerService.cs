using System;
using System.IO;
using AdventOfCode.Interfaces;

namespace AdventOfCode.Services;

public class FileHandlerService : IFileHandlerService
{

    public FileHandlerService()
    {
        
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
}