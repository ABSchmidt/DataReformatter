using System;
using System.Collections.Generic;
using Xunit;
using Newtonsoft.Json.Linq;

namespace DataReformatter.Application.Tests;

public class MapTests
{
    [Fact]
    public void Map_ValidDictionary_ReturnsJObjectWithSameData()
    {
        // Arrange
        var data = new Dictionary<string, string>
        {
            { "Name", "John" },
            { "Age", "25" },
            { "Country", "USA" }
        };

        // Act
        JObject result = JsonService.Map(data);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("John", result["Name"]?.ToString());
        Assert.Equal("25", result["Age"]?.ToString());
        Assert.Equal("USA", result["Country"]?.ToString());
    }

    [Fact]
    public void Map_EmptyDictionary_ReturnsEmptyJObject()
    {
        // Arrange
        var emptyData = new Dictionary<string, string>();

        // Act
        JObject result = JsonService.Map(emptyData);

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result); // Ensures the JObject has no properties
    }

    [Fact]
    public void Map_NullDictionary_ThrowsArgumentNullException()
    {
        // Arrange
        Dictionary<string, string> nullData = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => JsonService.Map(nullData));
    }

    [Fact]
    public void Map_DictionaryWithSpecialCharacters_ReturnsCorrectlyEscapedJObject()
    {
        // Arrange
        var specialCharData = new Dictionary<string, string>
        {
            { "Greeting", "Hello, \"World\"!" },
            { "Address", "123 Maple St\nAnytown" }
        };

        // Act
        JObject result = JsonService.Map(specialCharData);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Hello, \"World\"!", result["Greeting"]?.ToString());
        Assert.Equal("123 Maple St\nAnytown", result["Address"]?.ToString());
    }

    [Fact]
    public void Map_ValidJObject_ReturnsDictionaryWithSameData()
    {
        // Arrange
        var jsonObject = new JObject
        {
            { "Name", "John" },
            { "Age", "25" },
            { "Country", "USA" }
        };

        // Act
        Dictionary<string, string> result = JsonService.Map(jsonObject);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("John", result["Name"]);
        Assert.Equal("25", result["Age"]);
        Assert.Equal("USA", result["Country"]);
    }

    [Fact]
    public void Map_EmptyJObject_ReturnsEmptyDictionary()
    {
        // Arrange
        var emptyObject = new JObject();

        // Act
        Dictionary<string, string> result = JsonService.Map(emptyObject);

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result); // Ensures the dictionary has no elements
    }

    [Fact]
    public void Map_NullJObject_ThrowsNullReferenceException()
    {
        // Arrange
        JObject nullObject = null;

        // Act & Assert
        Assert.Throws<NullReferenceException>(() => JsonService.Map(nullObject));
    }

    [Fact]
    public void Map_JObjectWithNonStringValues_ThrowsInvalidCastException()
    {
        // Arrange
        var jsonObject = new JObject
        {
            { "Name", "John" },
            { "Age", 25 }, // Non-string value
            { "Country", "USA" }
        };

        // Act & Assert
        Assert.Throws<InvalidCastException>(() => JsonService.Map(jsonObject));
    }

    [Fact]
    public void Map_JObjectWithSpecialCharacters_ReturnsCorrectlyEscapedDictionary()
    {
        // Arrange
        var jsonObject = new JObject
        {
            { "Greeting", "Hello, \"World\"!" },
            { "Address", "123 Maple St\nAnytown" }
        };

        // Act
        Dictionary<string, string> result = JsonService.Map(jsonObject);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Hello, \"World\"!", result["Greeting"]);
        Assert.Equal("123 Maple St\nAnytown", result["Address"]);
    }
}
