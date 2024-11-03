using System;

namespace DataReformatter.Application;

public static class ApplicationService
{
    public static void FlattenJSON(string sourcePath, string outputPath)
    {
        Console.WriteLine("FlattenJson");
        var sourceContent = FileService.ReadFile(sourcePath);
        var sourceJson = JsonService.Parse(sourceContent);
        var flattenedJson = JsonService.Flatten(sourceJson);
        var serialized = JsonService.Serialize(flattenedJson);
        FileService.WriteFile(outputPath, serialized);
    }

    public static void UnflattenJSON(string sourcePath, string outputPath)
    {
        Console.WriteLine("UnflattenJson");
        var sourceContent = FileService.ReadFile(sourcePath);
        var sourceJson = JsonService.Parse(sourceContent);
        var unflattenedJson = JsonService.Unflatten(sourceJson);
        var serialized = JsonService.Serialize(unflattenedJson);
        FileService.WriteFile(outputPath, serialized);
    }

    public static void JsonToCsv(string sourcePath, string outputPath)
    {
        Console.WriteLine("JsonToCsv");
        var sourceContent = FileService.ReadFile(sourcePath);
        var sourceJson = JsonService.Parse(sourceContent);
        var flattenedJson = JsonService.Flatten(sourceJson);
        var sourceDict = JsonService.ToDictionary(flattenedJson);
        var serialized = CsvService.Serialize(sourceDict);
        FileService.WriteFile(outputPath, serialized);
    }
}
