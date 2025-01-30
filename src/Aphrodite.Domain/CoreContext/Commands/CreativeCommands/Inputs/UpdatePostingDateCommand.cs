using Aphrodite.Domain.Shared.Commands.Interfaces;
using Flunt.Notifications;

namespace Aphrodite.Domain.CoreContext.Commands.CreativeCommands.Inputs;

public class UpdatePostingDateCommand : Notifiable<Notification>, ICommand
{
    public DateTime PostingDate { get; set; }
    
    public bool Valid()
    {
        throw new NotImplementedException();
    }
}