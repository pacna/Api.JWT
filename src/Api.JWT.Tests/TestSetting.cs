using Api.JWT.Settings;

namespace Api.JWT.Tests;

public sealed class TestSetting : IApplicationSetting
{
    public string JwtSecret => "this is a really really really really long test secret";
    public string Issuer => "Test";
}