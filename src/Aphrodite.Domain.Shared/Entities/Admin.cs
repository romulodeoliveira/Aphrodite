using Aphrodite.Domain.Shared.ValueObjects;

namespace Aphrodite.Domain.Shared.Entities;

public class Admin : BaseUser
{
    public Admin(
        Name name, 
        Email email) : base(
            name, 
            email)
    {
    }
}