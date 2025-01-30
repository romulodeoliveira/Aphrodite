using Aphrodite.Domain.CoreContext.Commands.CommentCommands.Inputs;
using Aphrodite.Domain.Shared.Commands.Interfaces;
using Flunt.Notifications;
using Flunt.Validations;

namespace Aphrodite.Domain.CoreContext.Commands.CreativeCommands.Inputs;

public class AddCommentCommand : Notifiable<Notification>, ICommand
{
    public CreateCommentCommand Comment { get; set; }
    
    public bool Valid()
    {
        AddNotifications(new Contract<AddCommentCommand>()
            .Requires()
        );

        return IsValid;
    }
}