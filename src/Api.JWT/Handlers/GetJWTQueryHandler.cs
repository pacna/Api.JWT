using Api.JWT.Controllers.Models;
using Api.JWT.Services;
using MediatR;

namespace Api.JWT.Handlers;

public sealed class GetJWTQuery(string token) : IRequest<ClaimResponse>
{
    public string Token => token;

}

public class GetJWTQueryHandler(IAuthenticationService authService): IRequestHandler<GetJWTQuery, ClaimResponse>
{
    public Task<ClaimResponse> Handle(GetJWTQuery query, CancellationToken cancellationToken)
    {
        if (!string.IsNullOrEmpty(query.Token))
        {
            return Task.FromResult(new ClaimResponse(authService.GetClaims(query.Token)));
        }

        return null;
    }
}