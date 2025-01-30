using Aphrodite.Domain.Shared.ValueObjects;
using Flunt.Validations;

namespace Aphrodite.Domain.UserContext.ValueObjects;

public class Name : BaseValueObject
{
    public Name(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;

        AddNotifications(
            new Contract<Name>()
                .Requires()
                .IsTrue(firstName.Length < 30, "FirstName", "O nome não pode ser maior que 30 caracteres.")
                .IsNotNullOrEmpty(firstName, "FirstName", "O nome não pode estar em branco")
                .IsTrue(lastName.Length < 30, "LastName", "O sobrenome não pode ser maior que 30 caracteres.")
                .IsNotNullOrEmpty(lastName, "LastName", "O sobrenome não pode estar em branco")
            );
    }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    
    public override string ToString()
    {
        return $"{FirstName} {LastName}";
    }
}