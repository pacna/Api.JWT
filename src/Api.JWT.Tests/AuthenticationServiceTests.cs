using Api.JWT.Services;
using Microsoft.Extensions.Logging;
using Moq;

namespace Api.JWT.Tests;

public class AuthenticationServiceTests
{
    private readonly Mock<ILogger<AuthenticationService>> _logger = new();
    private readonly IAuthenticationService _service;

    public AuthenticationServiceTests()
    {
        _service = new AuthenticationService(new TestSetting(), _logger.Object);
    }

    [Fact]
    public void CanGenerateToken()
    {
        // ARRANGE
        Dictionary<string, string> claims = new()
        {
            { "test", "test"}
        };

        DateTime expireAt = DateTime.UtcNow.AddDays(1);

        // ACT
        string jwt = _service.GenerateToken(claims, expireAt);

        // ASSERT
        Assert.True(!string.IsNullOrEmpty(jwt));
    }

    [Fact]
    public void CanGetClaims()
    {
        // ARRANGE
        Dictionary<string, string> expectedClaims = new()
        {
            { "foo", "bar"}
        };

        DateTime expireAt = DateTime.UtcNow.AddDays(1);

        string jwt = _service.GenerateToken(expectedClaims, expireAt);

        // ACT
        Dictionary<string, string> claims = _service.GetClaims(jwt);

        // ASSERT
        Assert.NotNull(claims);
        Assert.Equal(expectedClaims["foo"], claims["foo"]);
    }
}