using System;
using Xunit;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DataReformatter.Application.Tests;

public class SerializeTests
{
    [Fact]
    public void Serialize_ValidJObject_ReturnsIndentedJsonString()
    {
        // Arrange
        var jsonObject = new JObject
        {
            ["Name"] = "John",
            ["Age"] = 25
        };

        // Act
        string result = JsonService.Serialize(jsonObject);

        // Assert
        Assert.NotNull(result);
        string expectedJson = @"{
  ""Name"": ""John"",
  ""Age"": 25
}";
        Assert.Equal(expectedJson, result);
    }

    [Fact]
    public void Serialize_EmptyJObject_ReturnsEmptyJsonObjectString()
    {
        // Arrange
        var emptyObject = new JObject();

        // Act
        string result = JsonService.Serialize(emptyObject);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("{}", result.Trim());
    }

    [Fact]
    public void Serialize_NullJObject_ThrowsArgumentNullException()
    {
        // Arrange
        JObject nullObject = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => JsonService.Serialize(nullObject));
    }

    [Fact]
    public void Serialize_JObjectWithNestedObjects_ReturnsIndentedJsonString()
    {
        // Arrange
        var nestedObject = new JObject
        {
            ["Name"] = "John",
            ["Address"] = new JObject
            {
                ["Street"] = "123 Maple St",
                ["City"] = "Anytown"
            }
        };

        // Act
        string result = JsonService.Serialize(nestedObject);

        // Assert
        Assert.NotNull(result);
        string expectedJson = @"{
  ""Name"": ""John"",
  ""Address"": {
    ""Street"": ""123 Maple St"",
    ""City"": ""Anytown""
  }
}";
        Assert.Equal(expectedJson, result);
    }
}
