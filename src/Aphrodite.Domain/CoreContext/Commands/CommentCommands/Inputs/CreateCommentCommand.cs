using Aphrodite.Domain.Shared.Commands.Interfaces;
using Flunt.Notifications;

namespace Aphrodite.Domain.CoreContext.Commands.CommentCommands.Inputs;

public class CreateCommentCommand : Notifiable<Notification>, ICommand
{
    public string Content { get; private set; }
    public Guid AuthorId { get; private set; }
    
    public bool Valid()
    {
        throw new NotImplementedException();
    }
}