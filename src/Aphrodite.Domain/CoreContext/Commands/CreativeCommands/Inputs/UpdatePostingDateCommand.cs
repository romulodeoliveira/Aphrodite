using Aphrodite.Domain.Shared.Commands.Interfaces;
using Flunt.Notifications;
using Flunt.Validations;

namespace Aphrodite.Domain.CoreContext.Commands.CreativeCommands.Inputs;

public class UpdatePostingDateCommand : Notifiable<Notification>, ICommand
{
    public DateTime PostingDate { get; set; }
    
    public bool Valid()
    {
        AddNotifications(new Contract<UpdatePostingDateCommand>()
            .Requires()
        );

        return IsValid;
    }
}