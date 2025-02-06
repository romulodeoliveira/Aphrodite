using Aphrodite.Domain.Shared.Commands.Interfaces;
using Flunt.Notifications;
using Flunt.Validations;

namespace Aphrodite.Domain.CoreContext.Commands.CommentCommands.Inputs;

public class CreateCommentCommand : Notifiable<Notification>, ICommand
{
    public CreateCommentCommand(string content, Guid authorId)
    {
        Content = content;
        AuthorId = authorId;
    }

    public string Content { get; set; }
    public Guid AuthorId { get; set; }
    
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