using Aphrodite.Domain.CoreContext.Entities;
using Aphrodite.Domain.Shared.Commands.Interfaces;
using Flunt.Notifications;

namespace Aphrodite.Domain.CoreContext.Commands.FileCommands.Inputs;

public class UpdateArchiveCommand : Notifiable<Notification>, ICommand
{
    public Byte[] File { get; set; }
    public Creative Creative { get; set; }
    
    public bool Valid()
    {
        throw new NotImplementedException();
    }
}