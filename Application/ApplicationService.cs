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

    public static void UnflattenJSON(string sourcePath, string outputPath)
    {
        Console.WriteLine("UnflattenJSON");
        var sourceContent = FileService.ReadFile(sourcePath);
        var sourceJson = JSONService.Parse(sourceContent);
        var unflattenedJson = JSONService.Unflatten(sourceJson);
        var serialized = JSONService.Serialize(unflattenedJson);
        FileService.WriteFile(outputPath, serialized);
    }
}
