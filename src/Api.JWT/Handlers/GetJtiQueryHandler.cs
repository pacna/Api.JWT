using Api.JWT.Controllers.Models;
using MediatR;

namespace Api.JWT.Handlers;

public sealed class GetJtiQuery(string id) : IRequest<JwtResponse>
{
    public string Jti => id;

}

public class GetJtiQueryHandler: IRequestHandler<GetJtiQuery, JwtResponse>
{
    public Task<JwtResponse> Handle(GetJtiQuery query, CancellationToken cancellationToken)
    {
        return Task.FromResult(new JwtResponse());
    }
}