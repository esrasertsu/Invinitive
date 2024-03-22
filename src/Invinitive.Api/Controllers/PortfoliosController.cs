using Invinitive.Application.Portfolios.Commands;
using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Invinitive.Api.Controllers;

[Route("{userId:guid}/portfolios")]
[AllowAnonymous]
public class PortfoliosController(ISender _mediator) : ApiController
{
    [HttpPost]
    public async Task<IActionResult> CreatePortfolioHierarchy(Guid userId, [FromBody] Dictionary<string, string> hierarchy)
    {
        var request = new CreatePortfolioHierarchyCommand(userId, hierarchy);
        var result = await _mediator.Send(request);

        return result.Match(
            hierarcy => CreatedAtAction(
                actionName: nameof(CreatePortfolioHierarchy),
                routeValues: new { UserId = userId },
                value: hierarcy),
            Problem);
    }
}