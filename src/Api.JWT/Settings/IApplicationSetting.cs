namespace Api.JWT.Settings;

public interface IApplicationSetting
{
    public string JwtSecret { get; }
    public string Issuer { get; }
}