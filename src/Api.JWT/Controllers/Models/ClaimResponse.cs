namespace Api.JWT.Controllers.Models;

public sealed class ClaimResponse(Dictionary<string, string> claims)
{
    public Dictionary<string, string> Claims => claims;
}