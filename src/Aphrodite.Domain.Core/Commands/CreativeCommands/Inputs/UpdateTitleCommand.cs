using Aphrodite.Domain.Shared.Commands.Interfaces;
using Flunt.Notifications;

namespace Aphrodite.Domain.Core.Commands.CreativeCommands.Inputs;

public class UpdateTitleCommand : Notifiable<Notification>, ICommand
{
    public string Title { get; set; }
    
    public bool Valid()
    {
        throw new NotImplementedException();
    }
}