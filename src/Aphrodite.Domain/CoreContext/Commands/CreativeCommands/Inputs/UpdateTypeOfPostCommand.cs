using Aphrodite.Domain.CoreContext.Enums;
using Aphrodite.Domain.Shared.Commands.Interfaces;
using Flunt.Notifications;

namespace Aphrodite.Domain.CoreContext.Commands.CreativeCommands.Inputs;

public class UpdateTypeOfPostCommand : Notifiable<Notification>, ICommand
{
    public ETypeOfPost TypeOfPost { get; set; }
    
    public bool Valid()
    {
        throw new NotImplementedException();
    }
}