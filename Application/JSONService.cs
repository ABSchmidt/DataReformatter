using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DataReformatter.Application;

public static class JsonService
{
    public static JObject Parse(string source)
    {
        try
        {
            var result = JObject.Parse(source);
            return result;
        }
        catch(JsonException ex)
        {
            throw new ParsingException("An error occurred parsing json.", ex);
        }
    }

    public static string Serialize(this JObject source)
    {
        if(source == null) throw new ArgumentNullException("source");
        string result = JsonConvert.SerializeObject(source, Formatting.Indented);
        return result;
    }

    public static JObject Map(Dictionary<string, string> source)
    {
        return JObject.FromObject(source);
    }

    public static Dictionary<string, string> Map(this JObject source)
    {
        return source.ToObject<Dictionary<string, string>>();
    }

    public static JObject Flatten(this JObject source, string cumulativeKey = "")
    {
        var result = new JObject();
        foreach(KeyValuePair<string, JToken> entry in source)
        {
            if(entry.Key.Contains('.'))
            {
                throw new Exception("Forbidden character in key");
            }
            JToken value = entry.Value;
            string newKey = cumulativeKey == string.Empty ? entry.Key : $"{cumulativeKey}.{entry.Key}";
            if(value.Type == JTokenType.Object)
            {
                var innerFlat = Flatten((JObject)value, newKey);
                foreach(JToken innerChild in innerFlat.Children())
                {
                    result.Add(innerChild);
                }
            }
            if(value.Type == JTokenType.String)
            {
                result.Add(newKey, value);
            }
        }
        
        return result;
    }

    public static JObject Unflatten(this JObject source)
    {
        var result = new JObject();
        foreach(KeyValuePair<string, JToken> sourceProperty in source)
        {
            var keySegments = sourceProperty.Key.Split('.');
            JObject currentObject = result;
            JProperty resultProperty;
            JObject nextObject = currentObject;
            for(int i = 0; i < keySegments.Count(); i++)
            {
                if(currentObject.ContainsKey(keySegments[i]))
                {
                    currentObject = (JObject)currentObject.Property(keySegments[i]).Value;
                    continue;
                }
                
                nextObject = new JObject();
                resultProperty = new JProperty(keySegments[i], nextObject);
                currentObject.Add(resultProperty);
                if(i == keySegments.Count() - 1)
                {
                    resultProperty.Value = sourceProperty.Value;
                    continue;
                }
                currentObject = nextObject;
            }
        }
        return result;
    }
}