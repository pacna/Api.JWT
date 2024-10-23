namespace Api.JWT.Controllers.Models;

public sealed class JWTResponse(string id, string token)
{
    public string Id => id;
    public string Token => token;
}