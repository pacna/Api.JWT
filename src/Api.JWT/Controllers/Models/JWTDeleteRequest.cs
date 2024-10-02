namespace Api.JWT.Controllers.Models;

public sealed class JWTDeleteRequest(string token)
{
    public string Token => token;
}