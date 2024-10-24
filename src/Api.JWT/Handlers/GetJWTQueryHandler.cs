using Api.JWT.Controllers.Models;
using Api.JWT.Repositories;
using Api.JWT.Repositories.Entities;
using Api.JWT.Services;
using MediatR;

namespace Api.JWT.Handlers;

public sealed class GetJWTQuery(string token) : IRequest<ClaimResponse>
{
    public string Token => token;

}

public class GetJWTQueryHandler(
    IAuthenticationService authService, 
    IJWTRepository repo): IRequestHandler<GetJWTQuery, ClaimResponse?>
{
    public async Task<ClaimResponse?> Handle(GetJWTQuery query, CancellationToken cancellationToken)
    {
        if (!await ValidateAsync(query.Token))
        {
            return null;
        }

        return new ClaimResponse(authService.GetClaims(query.Token));
    }

    private async Task<bool> ValidateAsync(string token)
    {
        JWTEntity? entity = await repo.GetByTokenAsync(token);

        return entity != null;
    }
}