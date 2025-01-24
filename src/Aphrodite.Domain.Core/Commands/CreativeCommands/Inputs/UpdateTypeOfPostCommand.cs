using Aphrodite.Domain.Core.Enums;
using Aphrodite.Domain.Shared.Commands.Interfaces;
using Flunt.Notifications;

namespace Aphrodite.Domain.Core.Commands.CreativeCommands.Inputs;

public class UpdateTypeOfPostCommand : Notifiable<Notification>, ICommand
{
    public ETypeOfPost TypeOfPost { get; set; }
    
    public bool Valid()
    {
        throw new NotImplementedException();
    }
}