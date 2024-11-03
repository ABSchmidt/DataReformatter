

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataReformatter.Application;

public static class CsvService
{
    public static Dictionary<string,string> Parse(string source)
    {
        var result = new Dictionary<string,string>();

        // Split the content by lines to get each row
        string[] rows = source.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
        
        foreach (string row in rows)
        {
            // Split each row by comma to get each cell
            string[] cells = row.Split(new[] { ',' }, StringSplitOptions.None);
            
            // Convert cells to a list and add it to the result
            //List<string> rowList = new List<string>(cells);
            result.Add(cells[0], cells[1]);
        }

        return result;
    }

    public static string Serialize(Dictionary<string,string> source)
    {
        StringBuilder csvBuilder = new StringBuilder();
        char separator = ';';

        // Iterate over each key-value pair in the dictionary
        foreach (var kvp in source)
        {
            // Escape keys and values to handle commas and special characters
            string key = kvp.Key;//EscapeCsvValue(kvp.Key);
            string value = kvp.Value;//EscapeCsvValue(kvp.Value);
            
            // Append the key and value as a new row in the CSV
            csvBuilder.AppendLine($"{key}{separator}{value}");
        }

        return csvBuilder.ToString();
    }
}