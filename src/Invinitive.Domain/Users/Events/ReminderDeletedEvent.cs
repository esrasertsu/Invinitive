using Invinitive.Domain.Common;

namespace Invinitive.Domain.Users.Events;

public record ReminderDeletedEvent(Guid ReminderId) : IDomainEvent;