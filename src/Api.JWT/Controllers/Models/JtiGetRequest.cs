namespace Api.JWT.Controllers.Models;

public sealed class JtiGetRequest(string id)
{ 
    public string Jti => id;
}