using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Api.JWT.Services;

internal class AuthenticationService(
    IConfiguration configuration, 
    ILogger<AuthenticationService> logger) : IAuthenticationService
{
    public string GenerateToken(Dictionary<string, string> claims, DateTime expireAt)
    {
        try
        {
            SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(configuration.GetSection("JwtSecret").Get<string>()!));
            JwtSecurityToken token = new(
                issuer: configuration.GetSection("Issuer").Get<string>()!,
                claims: ToClaimList(claims),
                expires: expireAt,
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        catch(Exception ex)
        {
            logger.LogError(ex.Message, [ex.Data]);

            return string.Empty;
        }
    }

    public Dictionary<string, string> GetClaims(string jwt)
    {
        try
        {
            JwtSecurityTokenHandler handler = new();
            JwtSecurityToken token = handler.ReadJwtToken(jwt);

            return ToDict(token.Claims);
        }
        catch(Exception ex)
        {
            logger.LogError(ex.Message, [ex.Data]);
            return [];
        }
    }

    private static List<Claim> ToClaimList(Dictionary<string, string> claims)
    {
        List<Claim> c = [];

        foreach(KeyValuePair<string, string> claim in claims)
        {
            c.Add(new Claim(claim.Key, claim.Value));
        }

        return c;
    }

    private static Dictionary<string, string> ToDict(IEnumerable<Claim> claims)
    {
        Dictionary<string, string> c = [];

        foreach(Claim claim in claims)
        {
            c.TryAdd(claim.Type, claim.Value);
        }

        return c;
    }
}