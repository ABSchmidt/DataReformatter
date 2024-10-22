using System;

namespace DataReformatter.Application;

public static class ApplicationService
{
    public static void FlattenJSON(string sourcePath, string outputPath)
    {
        Console.WriteLine("FlattenJSON");
        var sourceContent = FileService.ReadFile(sourcePath);
        var sourceJson = JSONService.Parse(sourceContent);
        var flattenedJson = JSONService.Flatten(sourceJson);
        var serialized = JSONService.Serialize(flattenedJson);
        FileService.WriteFile(outputPath, serialized);
    }
}
