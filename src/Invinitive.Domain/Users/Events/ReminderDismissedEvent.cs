using Invinitive.Domain.Common;

namespace Invinitive.Domain.Users.Events;

public record ReminderDismissedEvent(Guid ReminderId) : IDomainEvent;