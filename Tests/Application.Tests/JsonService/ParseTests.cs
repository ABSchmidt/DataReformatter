using System;
using Xunit;
using Newtonsoft.Json.Linq;

namespace DataReformatter.Application.Tests;

public class ParseTests
{
    [Fact]
    public void Parse_ValidJsonString_ReturnsJObject()
    {
        // Arrange  
        string jsonString = "{ \"Name\": \"John\", \"Age\": \"25\" }";

        // Act
        JObject result = JsonService.Parse(jsonString);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("John", result["Name"]?.ToString());
        Assert.Equal("25", result["Age"]?.ToString());
    }

    [Fact]
    public void Parse_EmptyJsonString_ReturnsEmptyJObject()
    {
        // Arrange
        string jsonString = "{}";

        // Act
        JObject result = JsonService.Parse(jsonString);

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result); // Verifies the JObject is empty
    }

    [Fact]
    public void Parse_InvalidJsonString_ThrowsParsingException()
    {
        // Arrange
        string invalidJson = "{ \"Name\": \"John\", \"Age\": 25 "; // Missing closing brace

        // Act & Assert
        Assert.Throws<ParsingException>(() => JsonService.Parse(invalidJson));
    }

    [Fact]
    public void Parse_NullString_ThrowsArgumentNullException()
    {
        // Arrange
        string nullString = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => JsonService.Parse(nullString));
    }
}
