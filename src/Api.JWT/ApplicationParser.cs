using Api.JWT.Settings;

internal static class ApplicationParser
{
    public static ApplicationSetting Parse(IConfiguration configuration)
    {
        return new ApplicationSetting(
            jwtSecret: configuration.GetSection("JwtSecret").Get<string>()!,
            issuer: configuration.GetSection("Issuer").Get<string>()!
        );
    }
}