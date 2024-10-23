using Api.JWT.Controllers.Models;
using Api.JWT.Repositories;
using Api.JWT.Repositories.Entities;
using MediatR;

namespace Api.JWT.Handlers;

public sealed class GetJtiQuery(string id) : IRequest<JWTResponse>
{
    public string Jti => id;

}

public class GetJtiQueryHandler(IJWTRepository repo): IRequestHandler<GetJtiQuery, JWTResponse?>
{
    public async Task<JWTResponse?> Handle(GetJtiQuery query, CancellationToken cancellationToken)
    {
        JWTEntity? entity = await repo.GetAsync(query.Jti);
        
        return entity?.ToResponse();
    }
}