namespace Api.JWT.Settings;

internal sealed class ApplicationSetting(string jwtSecret, string issuer) : IApplicationSetting
{
    public string JwtSecret => jwtSecret;
    public string Issuer => issuer;
}