using System.IO;

namespace AdventOfCode.Interfaces;

public interface IFileHandlerService
{
    public static abstract DirectoryInfo CreateCacheDirectory(string name);
}