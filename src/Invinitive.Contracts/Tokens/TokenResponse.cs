namespace Invinitive.Contracts.Tokens;

public record TokenResponse(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    string Token);