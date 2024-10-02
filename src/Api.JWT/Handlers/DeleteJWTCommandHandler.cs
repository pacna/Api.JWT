using MediatR;

namespace Api.JWT.Handlers;

public sealed class DeleteJWTCommand(string token) : INotification
{
    public string Token => token;
}

public class DeleteJWTCommandHandler : INotificationHandler<DeleteJWTCommand>
{
    public Task Handle(DeleteJWTCommand notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}