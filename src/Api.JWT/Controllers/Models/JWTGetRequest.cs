namespace Api.JWT.Controllers.Models;

public sealed class JWTGetRequest(string token)
{ 
    public string Token => token;
}