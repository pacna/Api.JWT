namespace Api.JWT.Services;

public interface IAuthenticationService
{
    string GenerateToken(Dictionary<string, string> claims, DateTime expireAt);
    Dictionary<string, string> GetClaims(string jwt);
}