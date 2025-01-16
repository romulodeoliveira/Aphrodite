using Flunt.Notifications;

namespace Aphrodite.Domain.Shared.Entities;

public abstract class BaseEntity : Notifiable<Notification>
{
    public BaseEntity()
    {
        Id = Guid.NewGuid();
    }

    public Guid Id { get; private set; }
}