using System.IO;

namespace DataReformatter.Application;

public static class FileService
{
    public static string ReadFile(string path)
    {
        var content = File.ReadAllText(path);
        return content;
    }

    public static void WriteFile(string path, string content)
    {
        File.WriteAllText(path, content);
    }
}
