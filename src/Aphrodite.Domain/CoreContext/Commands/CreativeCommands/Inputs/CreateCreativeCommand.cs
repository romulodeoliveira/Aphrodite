using Aphrodite.Domain.CoreContext.Enums;
using Aphrodite.Domain.Shared.Commands.Interfaces;
using Aphrodite.Domain.UserContext.Enums;
using Flunt.Notifications;
using Flunt.Validations;

namespace Aphrodite.Domain.CoreContext.Commands.CreativeCommands.Inputs;

public class CreateCreativeCommand : Notifiable<Notification>, ICommand
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime PostingDate { get; set; }
    public Guid AdminId { get; set; }
    public Guid CustomerId { get; set; }
    public EDocumentType Type { get; set; }
    public ETypeOfPost TypeOfPost { get; set; }
    
    public bool Valid()
    {
        AddNotifications(new Contract<CreateCreativeCommand>()
            .Requires()
            .IsNotNullOrEmpty(AdminId.ToString(), "AdminId", "O ID do admin é obrigatório.")
            .IsFalse(AdminId == Guid.Empty, "AdminId", "O ID do admin é inválido.")
            .IsNotNullOrEmpty(CustomerId.ToString(), "CustomerId", "O ID do cliente é obrigatório.")
            .IsFalse(CustomerId == Guid.Empty, "CustomerId", "O ID do cliente é inválido.")
        );

        return IsValid;
    }
}