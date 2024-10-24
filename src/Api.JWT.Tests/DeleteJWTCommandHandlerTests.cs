using Api.JWT.Handlers;
using Api.JWT.Repositories;
using Moq;

namespace Api.JWT.Tests;

public class DeleteJWTCommandHandlerTests
{
    private readonly Mock<IJWTRepository> _repo = new(MockBehavior.Strict);
    private readonly DeleteJWTCommandHandler _handler;

    public DeleteJWTCommandHandlerTests()
    {
        _handler = new DeleteJWTCommandHandler(_repo.Object);
    }

    [Fact]
    public async Task CanNotifyToDeleteAsync()
    {
        // ARRANGE
        DeleteJWTCommand command = new("mypreciousjwttoken");
        _repo
            .Setup(m => m.DeleteByTokenAsync(command.Token))
            .Returns(Task.CompletedTask);

        // ACT
        await _handler.Handle(command, default);

        // ASSERT
        _repo.Verify(m => m.DeleteByTokenAsync(command.Token), Times.Once);
    }
}