namespace Aphrodite.Domain.Shared.Entities;

public abstract class BaseUser : BaseEntity
{
    protected BaseUser(
        string firstName, 
        string lastName, 
        string email, 
        DateOnly birthDate, 
        DateTime createdDate, 
        DateTime? lastModified, 
        bool isActive)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        BirthDate = birthDate;
        CreatedDate = createdDate;
        LastModified = lastModified;
        IsActive = isActive;
    }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public DateOnly BirthDate { get; private set; }
    public DateTime CreatedDate { get; private set; }
    public DateTime? LastModified { get; private set; }
    public bool IsActive { get; private set; }
    
    public override string ToString()
    {
        return $"{FirstName} {LastName}";
    }
}