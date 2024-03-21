using ErrorOr;

namespace Invinitive.Domain.Users;

public static class UserErrors
{
    public static Error CannotCreateMoreRemindersThanSubscriptionAllows { get; } = Error.Validation(
        code: "UserErrors.CannotCreateMoreRemindersThanSubscriptionAllows",
        description: "Cannot create more reminders than subscription allows");
}