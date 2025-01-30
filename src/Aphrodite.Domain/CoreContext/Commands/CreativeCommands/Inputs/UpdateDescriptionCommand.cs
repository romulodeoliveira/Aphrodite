using Aphrodite.Domain.Shared.Commands.Interfaces;
using Flunt.Notifications;

namespace Aphrodite.Domain.CoreContext.Commands.CreativeCommands.Inputs;

public class UpdateDescriptionCommand : Notifiable<Notification>, ICommand
{
    public string Description { get; set; }
    
    public bool Valid()
    {
        throw new NotImplementedException();
    }
}