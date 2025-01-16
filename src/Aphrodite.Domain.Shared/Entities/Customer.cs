namespace Aphrodite.Domain.Shared.Entities;

public class Customer : BaseUser
{
    public Customer(
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