using CleanArchitecture.Contracts.Tokens;
using Invinitive.Application.Tokens.Queries;
using Invinitive.Application.Tokens.Responses;
using Invinitive.Contracts.Tokens;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Invinitive.Api.Controllers;

[Route("tokens")]
[AllowAnonymous]
public class TokensController(ISender _mediator) : ApiController
{
    [HttpPost("generate")]
    public async Task<IActionResult> GenerateToken(GenerateTokenRequest request)
    {
        var query = new GenerateTokenQuery(request.Id, request.FirstName, request.LastName, request.Email, request.Permissions, request.Roles);

        var result = await _mediator.Send(query);

        return result.Match(
            generateTokenResponse => Ok(ToDto(generateTokenResponse)),
            Problem);
    }

    private static TokenResponse ToDto(GenerateTokenResponse token)
    {
        return new TokenResponse(
            token.Id,
            token.FirstName,
            token.LastName,
            token.Email,
            token.Token);
    }
}