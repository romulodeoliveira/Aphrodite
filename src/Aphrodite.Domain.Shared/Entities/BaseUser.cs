using Aphrodite.Domain.Shared.ValueObjects;
using Flunt.Validations;

namespace Aphrodite.Domain.Shared.Entities;

public abstract class BaseUser : BaseEntity
{
    protected BaseUser(
        Name name,
        Email email, 
        DateOnly birthDate)
    {
        Name = name;
        Email = email;
        BirthDate = birthDate;
        CreatedDate = DateTime.Now;
        
        AddNotifications(
            new Contract<BaseUser>()
                .Requires()
                .IsNotNull(name, "Name", "O nome não pode estar em branco.")
                .IsNotNull(email, "Email", "O e-mail não pode estar em branco.")
                .IsLowerOrEqualsThan(birthDate.ToDateTime(TimeOnly.MinValue), DateTime.Now, "BirthDate", "A data de nascimento deve ser no passado")
            );
    }

    public Name Name { get; private set; }
    public Email Email { get; private set; }
    public DateOnly? BirthDate { get; private set; }
    public DateTime CreatedDate { get; private set; }
    public DateTime? LastModified { get; private set; }
    public bool IsActive { get; private set; }

    public void AddBirthDate(DateOnly birthDate)
    {
        BirthDate = birthDate;
        LastModified = DateTime.Now;
        
        AddNotifications(
            new Contract<BaseUser>()
                .Requires()
                .IsLowerOrEqualsThan(birthDate.ToDateTime(TimeOnly.MinValue), DateTime.Now, "BirthDate",
                    "A data de nascimento deve ser no passado")
        );
    }

    public void MarkAsActive()
    {
        IsActive = true;
    }

    public void MarkAsInactive()
    {
        IsActive = false;
    }
}