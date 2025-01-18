using Flunt.Validations;

namespace Aphrodite.Domain.Shared.ValueObjects;

public class Email : BaseValueObject
{
    public Email(string address)
    {
        Address = address;

        AddNotifications(new Contract<Email>()
            .Requires()
            .IsEmail(Address, "Address", "Endereço de e-mail inválido")
        );
    }

    public string Address { get; private set; }
}