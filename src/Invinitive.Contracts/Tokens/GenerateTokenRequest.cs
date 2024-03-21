namespace Invinitive.Contracts.Tokens;

public record GenerateTokenRequest(
    Guid? Id,
    string FirstName,
    string LastName,
    string Email,
    List<string> Permissions,
    List<string> Roles);