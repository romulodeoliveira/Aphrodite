namespace Aphrodite.Domain.Shared.Entities;

public class Admin : BaseUser
{
    public Admin(
        string firstName, 
        string lastName, 
        string email, 
        DateOnly birthDate, 
        bool isActive) : base(
            firstName, 
            lastName, 
            email, 
            birthDate)
    {
    }
}