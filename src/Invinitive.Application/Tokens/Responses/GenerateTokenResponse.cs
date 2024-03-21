namespace Invinitive.Application.Tokens.Responses;

public record GenerateTokenResponse(Guid Id, string FirstName, string LastName, string Email, string Token);