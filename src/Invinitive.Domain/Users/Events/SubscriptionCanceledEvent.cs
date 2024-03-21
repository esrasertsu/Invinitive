using Invinitive.Domain.Common;

namespace Invinitive.Domain.Users.Events;

public record SubscriptionCanceledEvent(User User, Guid SubscriptionId) : IDomainEvent;