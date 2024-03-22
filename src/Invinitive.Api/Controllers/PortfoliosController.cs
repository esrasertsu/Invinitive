using Invinitive.Application.Portfolios.Commands;
using Invinitive.Application.Portfolios.Responses;
using Invinitive.Application.Tokens.Queries;
using Invinitive.Application.Tokens.Responses;
using Invinitive.Contracts.Tokens;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Invinitive.Api.Controllers;

[Route("portfolios")]
[AllowAnonymous]
public class PortfoliosController(ISender _mediator) : ApiController
{
    [HttpPost("generate")]
    public async Task<IActionResult> CreatePortfolioHierarchy(Guid userId, [FromBody] Dictionary<string, string> hierarchy)
    {
        var request = new CreatePortfolioHierarchyCommand { UserId = userId, Hierarchy = hierarchy };
        var response = await _mediator.Send(request);

        return response.Match(
            hierarcy => CreatedAtAction(
                actionName: nameof(CreatePortfolioHierarchy),
                routeValues: new { UserId = userId },
                value: hierarcy),
            Problem);
    }
}