using Api.JWT.Controllers.Models;
using MediatR;

namespace Api.JWT.Handlers;

public sealed class CreateJWTCommand(
    Dictionary<string, string> claims,
    DateTime expireAt) : IRequest<ClaimResponse>
{
    public Dictionary<string, string> Claims => claims;
    public DateTime ExpireAt => expireAt;
}

public class CreatJWTCommandHandler: IRequestHandler<CreateJWTCommand, ClaimResponse>
{
    public Task<ClaimResponse> Handle(CreateJWTCommand command, CancellationToken cancellationToken)
    {
        return Task.FromResult(new ClaimResponse(new Dictionary<string, string>() { {"Hi", "Foo"}}));
    }
}