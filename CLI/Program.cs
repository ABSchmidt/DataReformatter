using System;
using DataReformatter.Application;

namespace DataReformatter.CLI;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        foreach(string arg in args)
        {
            Console.WriteLine(arg);
        }
        ApplicationService.FlattenJSON("path-to-source", "path-to-output");
        Console.ReadKey();
    }
}
