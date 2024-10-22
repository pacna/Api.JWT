using Api.JWT.Controllers.Models;
using Api.JWT.Handlers;

namespace Api.JWT.Controllers;

internal static class MapperExtension
{
    public static GetJWTQuery ToQuery(this JWTGetRequest request) => new(request.Token);

    public static GetJtiQuery ToQuery(this JtiGetRequest request) => new(request.Jti);

    public static CreateJWTCommand ToCommand(this JWTPostRequest request) => new(request.Claims, request.ExpireAt);

    public static DeleteJWTCommand ToCommand(this JWTDeleteRequest request) => new(request.Token);
}