using System;
using DataReformatter.Application;

namespace DataReformatter.CLI;

class Program
{
    static void Main(string[] args)
    {
        foreach(string arg in args)
        {
            Console.WriteLine(arg);
        }
        string sourcePath = "D:\\Programming\\Repositories\\DataReformatter\\Assets\\Source\\i18n.json";
        string outputPath = "D:\\Programming\\Repositories\\DataReformatter\\Assets\\Output\\result.json";
        //Console.WriteLine("Hello, World!");
        ApplicationService.FlattenJSON(sourcePath, outputPath);
        //Console.ReadKey();
    }
}
