using Aphrodite.Domain.CoreContext.Commands.CommentCommands.Inputs;
using Aphrodite.Domain.Shared.Commands.Interfaces;
using Flunt.Notifications;

namespace Aphrodite.Domain.CoreContext.Commands.CreativeCommands.Inputs;

public class UpdateImageOrVideoCommand : Notifiable<Notification>, ICommand
{
    public Byte[] File { get; set; }
    public CreateCommentCommand Comment { get; set; }
    
    public bool Valid()
    {
        throw new NotImplementedException();
    }
}