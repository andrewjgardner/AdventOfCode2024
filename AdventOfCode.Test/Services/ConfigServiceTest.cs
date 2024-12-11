using System.Reflection;
using AdventOfCode.Services;
using Microsoft.Extensions.Configuration;

namespace AdventOfCode.Test.Services;

[TestFixture]
public class ConfigServiceTest
{
   [Test]
   public void GetConfigItem_WhenKeyExists_ReturnsValue()
   {
       // Arrange
       var configService = new ConfigService();
       var key = "TestKey";
       var expectedValue = "TestValue";
       var config = new ConfigurationBuilder()
           .AddInMemoryCollection(new Dictionary<string, string>
           {
               {key, expectedValue}
           }!)
           .Build();
       var field = typeof(ConfigService)
           .GetField("_config", BindingFlags.NonPublic | BindingFlags.Instance);
       field?.SetValue(configService, config);
       
       // Act
       var actualValue = configService.GetConfigItem(key);
       
       // Assert
         Assert.That(actualValue, Is.EqualTo(expectedValue));
   }
   
}
