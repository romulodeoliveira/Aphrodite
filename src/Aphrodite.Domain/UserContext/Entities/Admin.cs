using Aphrodite.Domain.UserContext.ValueObjects;

namespace Aphrodite.Domain.UserContext.Entities;

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