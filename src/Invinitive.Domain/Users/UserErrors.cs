using ErrorOr;

namespace Invinitive.Domain.Users;

public static class UserErrors
{
    public static Error CannotCreateMore { get; } = Error.Validation(
        code: "UserErrors.CannotCreateMore",
        description: "Cannot create more");
}