﻿using System;
using DataReformatter.Application;

namespace DataReformatter.CLI;

class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine("Hello, World!");
        foreach(string arg in args)
        {
            Console.WriteLine(arg);
        }
        
        // string nestedSourcePath = "D:\\Programming\\Repositories\\DataReformatter\\Assets\\Source\\nested.json";
        // string flattenedOutputPath = "D:\\Programming\\Repositories\\DataReformatter\\Assets\\Output\\flattened.json";
        // ApplicationService.FlattenJSON(nestedSourcePath, flattenedOutputPath);
        
        // string flatSourcePath = "D:\\Programming\\Repositories\\DataReformatter\\Assets\\Source\\flat.json";
        // string unflattenedOutputPath = "D:\\Programming\\Repositories\\DataReformatter\\Assets\\Output\\unflattened.json";
        // ApplicationService.UnflattenJSON(flatSourcePath, unflattenedOutputPath);
        
        string nestedSourcePath = "C:\\Users\\AndersBastianChristi\\Privat\\Repos\\DataReformatter\\Assets\\Source\\nested.json";
        string csvOutputPath = "C:\\Users\\AndersBastianChristi\\Privat\\Repos\\DataReformatter\\Assets\\Output\\result.csv";
        ApplicationService.JsonToCsv(nestedSourcePath, csvOutputPath);
        //Console.ReadKey();
    }
}
