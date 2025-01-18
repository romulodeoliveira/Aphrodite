using Aphrodite.Domain.Shared.ValueObjects;
using Flunt.Validations;

namespace Aphrodite.Domain.Shared.Entities;

public class Customer : BaseUser
{
    public Customer(
        Name name, 
        Email email, 
        DateOnly birthDate, 
        Document document) : base(
            name, 
            email, 
            birthDate)
    {
        Document = document;

        AddNotifications(new Contract<Customer>()
            .Requires()
            .IsNotNull(document, "Document", "É necessário inserir o documento.")
        );

    }
    
    public Document Document { get; private set; }
}