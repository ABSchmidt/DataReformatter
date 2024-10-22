using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DataReformatter.Application;

public static class JSONService
{
    public static JObject Parse(string content)
    {
        var jsonObj = JObject.Parse(content);
        return jsonObj;
    }

    public static string Serialize(JObject source)
    {
        string result = JsonConvert.SerializeObject(source, Formatting.Indented);
        return result;
    }

    public static JObject Flatten(JObject source, string existingPath = "")
    {
        var result = new JObject();
        foreach(KeyValuePair<string, JToken> kvp in source)
        {
            //string name = kvp.Key;
            JToken value = kvp.Value;
            string path = existingPath == string.Empty ? kvp.Key : $"{existingPath}.{kvp.Key}";
            //var type = value.Type;
            if(value.Type == JTokenType.Object)
            {
                //JObject innerObj = (JObject)value;
                var innerFlat = Flatten((JObject)value, path);
                foreach(JToken innerChild in innerFlat.Children())
                {
                    result.Add(innerChild);
                }
            }
            if(value.Type == JTokenType.String)
            {
                result.Add(path, value);
            }
        }
        return result;
    }
}