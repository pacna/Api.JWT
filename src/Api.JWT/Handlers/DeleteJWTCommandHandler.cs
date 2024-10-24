using Api.JWT.Repositories;
using MediatR;

namespace Api.JWT.Handlers;

public sealed class DeleteJWTCommand(string token) : INotification
{
    public string Token => token;
}

public class DeleteJWTCommandHandler(IJWTRepository repo) : INotificationHandler<DeleteJWTCommand>
{
    public async Task Handle(DeleteJWTCommand notification, CancellationToken cancellationToken)
    {
        await repo.DeleteByTokenAsync(notification.Token);
    }
}