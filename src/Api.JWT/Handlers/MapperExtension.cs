using Api.JWT.Controllers.Models;
using Api.JWT.Repositories.Entities;

namespace Api.JWT.Handlers;

internal static class MapperExtension
{
    public static JWTResponse ToResponse(this JWTEntity entity) => new JWTResponse(entity.Id, entity.Token);
}