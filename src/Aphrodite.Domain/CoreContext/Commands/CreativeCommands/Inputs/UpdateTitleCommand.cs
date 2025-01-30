using Aphrodite.Domain.Shared.Commands.Interfaces;
using Flunt.Notifications;
using Flunt.Validations;

namespace Aphrodite.Domain.CoreContext.Commands.CreativeCommands.Inputs;

public class UpdateTitleCommand : Notifiable<Notification>, ICommand
{
    public string Title { get; set; }
    
    public bool Valid()
    {
        AddNotifications(new Contract<UpdateTitleCommand>()
            .Requires()
        );

        return IsValid;
    }
}