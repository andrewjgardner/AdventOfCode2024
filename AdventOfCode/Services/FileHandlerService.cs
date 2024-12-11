using System;
using System.IO;
using AdventOfCode.Interfaces;

namespace AdventOfCode.Services;

public class FileHandlerService : IFileHandlerService
{
    public FileHandlerService()
    {
    }

    public static DirectoryInfo CreateCacheDirectory(string? name)
    {
        var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        var appDirectory = Path.Combine(appDataPath, name);
        return Directory.CreateDirectory(appDirectory);
    }


}