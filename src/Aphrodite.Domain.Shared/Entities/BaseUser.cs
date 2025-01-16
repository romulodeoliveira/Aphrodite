using Flunt.Validations;

namespace Aphrodite.Domain.Shared.Entities;

public abstract class BaseUser : BaseEntity
{
    protected BaseUser(
        string firstName, 
        string lastName, 
        string email, 
        DateOnly birthDate)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        BirthDate = birthDate;
        CreatedDate = DateTime.Now;
        
        AddNotifications(
            new Contract<BaseUser>()
                .Requires()
                .IsTrue(firstName.Length < 30, "FirstName", "O nome não pode ser maior que 30 caracteres.")
                .IsNotNullOrEmpty(firstName, "FirstName", "O nome não pode estar em branco")
                .IsTrue(lastName.Length < 30, "LastName", "O sobrenome não pode ser maior que 30 caracteres.")
                .IsNotNullOrEmpty(lastName, "LastName", "O sobrenome não pode estar em branco")
                .IsEmail(email, "Email", "O endereço de e-mail precisa ser válido")
                .IsLowerOrEqualsThan(birthDate.ToDateTime(TimeOnly.MinValue), DateTime.Now, "BirthDate", "A data de nascimento deve ser no passado")
            );
    }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public DateOnly? BirthDate { get; private set; }
    public DateTime CreatedDate { get; private set; }
    public DateTime? LastModified { get; private set; }
    public bool IsActive { get; private set; }
    
    public override string ToString()
    {
        return $"{FirstName} {LastName}";
    }

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