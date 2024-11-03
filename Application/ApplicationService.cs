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
        var serialized = JsonService
                            .Parse(sourceContent)
                            .Unflatten()
                            .Serialize();
        FileService.WriteFile(outputPath, serialized);
    }

    public static void JsonToCsv(string sourcePath, string outputPath)
    {
        Console.WriteLine("JsonToCsv");
        var sourceContent = FileService.ReadFile(sourcePath);
        var sourceDict = JsonService
                            .Parse(sourceContent)
                            .Flatten()
                            .ToDictionary();
        var serialized = CsvService.Serialize(sourceDict);
        FileService.WriteFile(outputPath, serialized);
    }


}
