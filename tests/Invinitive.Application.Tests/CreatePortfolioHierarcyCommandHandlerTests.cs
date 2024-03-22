namespace Invinitive.Application.Tests;

[Collection(WebAppFactoryCollection.CollectionName)]
public class CreatePortfolioHierarcyTests(WebAppFactory webAppFactory)
{
    private readonly IMediator _mediator = webAppFactory.CreateMediator();

    [Fact]
    public async Task CreatePortfolioHierarcy()
    {
        // Arrange
        var command = new CreatePortfolioHierarchyCommand();

        // Act
        var result = await _mediator.Send(command);

        // Assert
        result.IsError.Should().BeFalse();
        result.Value.AssertCreatedFrom(command);
    }
}