using System.Net;
using AdventOfCode.Interfaces;
using AdventOfCode.Services;
using Moq;
using Moq.Protected;

namespace AdventOfCode.Test.Services;

public class AdventApiServiceTests
{
    private Mock<IConfigService> _mockConfigService;

    [SetUp]
    public void Setup()
    {
        _mockConfigService = new Mock<IConfigService>();
        _mockConfigService.Setup(config => config.GetConfigItem("AdventOfCodeURL"))
            .Returns("http://testurl.com/api/data");
        _mockConfigService.Setup(config => config.GetConfigItem("UserAgentText")).Returns("testagent");
        _mockConfigService.Setup(config => config.GetConfigItem("Cookie")).Returns("testcookie");
    }

    [Test]
    public async Task RetrieveTestInputByDay_WhenCalled_ReturnsString()
    {
        // Arrange

        var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);

        handlerMock
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent("test content"),
            })
            .Verifiable();

        var httpClient = new HttpClient(handlerMock.Object);
        var service = new AdventApiService(_mockConfigService.Object, httpClient);

        // Act
        var result = await service.RetrieveTestInputByDay(1);

        // Assert
        Assert.That(result, Is.EqualTo("test content"));
    }
    
    [Test]
    public void RetrieveTestInputByDay_WhenCalled_ThrowsException()
    {
        // Arrange

        var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);

        handlerMock
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.BadRequest,
                Content = new StringContent("test content")
            })
            .Verifiable();

        var httpClient = new HttpClient(handlerMock.Object);
        var service = new AdventApiService(_mockConfigService.Object, httpClient);

        
        // Act * Assert
        Assert.That(async () => await service.RetrieveTestInputByDay(1), Throws.InvalidOperationException,
            "URL: http://testurl.com/api/data/1/input returned status code: BadRequest");
    }
}