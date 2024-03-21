using ErrorOr;
using Invinitive.Application.Common.Interfaces;
using Invinitive.Application.Tokens.Responses;
using MediatR;

namespace Invinitive.Application.Tokens.Queries.Generate;

public class GenerateTokenQueryHandler(IJwtTokenGenerator _jwtTokenGenerator) : IRequestHandler<GenerateTokenQuery, ErrorOr<GenerateTokenResponse>>
{
    public Task<ErrorOr<GenerateTokenResponse>> Handle(GenerateTokenQuery query, CancellationToken cancellationToken)
    {
        var id = query.Id ?? Guid.NewGuid();

        var token = _jwtTokenGenerator.GenerateToken(
            id,
            query.FirstName,
            query.LastName,
            query.Email,
            query.Permissions,
            query.Roles);

        var authResult = new GenerateTokenResponse(
            id,
            query.FirstName,
            query.LastName,
            query.Email,
            token);

        return Task.FromResult(ErrorOrFactory.From(authResult));
    }
}