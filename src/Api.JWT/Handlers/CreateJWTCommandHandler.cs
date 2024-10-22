using System.IdentityModel.Tokens.Jwt;
using Api.JWT.Repositories;
using Api.JWT.Repositories.Entities;
using Api.JWT.Services;
using MediatR;

namespace Api.JWT.Handlers;

public sealed class CreateJWTCommand(
    Dictionary<string, string> claims,
    DateTime expireAt) : IRequest<string>
{
    public Dictionary<string, string> Claims => claims;
    public DateTime ExpireAt => expireAt;
}

public class CreateJWTCommandHandler(
    IAuthenticationService authService,
    IJWTRepository repo): IRequestHandler<CreateJWTCommand, string>
{
    public async Task<string> Handle(CreateJWTCommand command, CancellationToken cancellationToken)
    {
        Dictionary<string, string> claims = command.Claims;
        string jtiId = Guid.NewGuid().ToString();
        claims.TryAdd(JwtRegisteredClaimNames.Jti, jtiId);

        string token = authService.GenerateToken(claims, command.ExpireAt);

        JWTEntity entity = new(jtiId, token);

        await repo.AddAsync(entity);
        return entity.Token;
    }
}