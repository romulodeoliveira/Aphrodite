using Aphrodite.Domain.UserContext.ValueObjects;
using Flunt.Validations;

namespace Aphrodite.Domain.UserContext.Entities;

public class Customer : BaseUser
{
    public Customer(
        Name name, 
        Email email, 
        Document document) : base(
            name, 
            email)
    {
        Document = document;

        AddNotifications(new Contract<Customer>()
            .Requires()
            .IsNotNull(document, "Document", "É necessário inserir o documento.")
        );

    }
    
    public Document Document { get; private set; }
}