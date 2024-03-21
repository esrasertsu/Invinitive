using ErrorOr;
using Invinitive.Application.Tokens.Responses;
using MediatR;

namespace Invinitive.Application.Tokens.Queries;

public record GenerateTokenQuery(
    Guid? Id,
    string FirstName,
    string LastName,
    string Email,
    List<string> Permissions,
    List<string> Roles) : IRequest<ErrorOr<GenerateTokenResponse>>;
