using Aphrodite.Domain.Shared.Commands.Interfaces;
using Flunt.Notifications;
using Flunt.Validations;

namespace Aphrodite.Domain.CoreContext.Commands.CommentCommands.Inputs;

public class CreateCommentCommand : Notifiable<Notification>, ICommand
{
    public string Content { get; private set; }
    public Guid AuthorId { get; private set; }
    
    public bool Valid()
    {
        AddNotifications(new Contract<CreateCommentCommand>()
            .Requires()
            .IsNotNullOrEmpty(AuthorId.ToString(), "AuthorId", "O ID do autor é obrigatório.")
            .IsFalse(AuthorId == Guid.Empty, "AuthorId", "O ID do autor é inválido.")
        );

        return IsValid;
    }
}