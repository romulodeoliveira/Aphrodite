using Aphrodite.Domain.Core.Commands.CommentCommands.Inputs;
using Aphrodite.Domain.Shared.Commands.Interfaces;
using Flunt.Notifications;

namespace Aphrodite.Domain.Core.Commands.CreativeCommands.Inputs;

public class AddCommentCommand : Notifiable<Notification>, ICommand
{
    public CreateCommentCommand Comment { get; set; }
    
    public bool Valid()
    {
        throw new NotImplementedException();
    }
}