using Api.JWT.Controllers.Models;
using Api.JWT.Handlers;

namespace Api.JWT.Controllers;

internal static class MapperExtension
{
    public static CreateJWTCommand ToCommand(this JWTPostRequest request)
    {
        return new CreateJWTCommand(request.Claims, request.ExpireAt);
    }

    public static DeleteJWTCommand ToCommand(this JWTDeleteRequest request)
    {
        return new DeleteJWTCommand(request.Token);
    }
}