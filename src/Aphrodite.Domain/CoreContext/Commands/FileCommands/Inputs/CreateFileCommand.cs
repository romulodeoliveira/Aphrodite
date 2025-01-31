using Aphrodite.Domain.CoreContext.Entities;
using Aphrodite.Domain.Shared.Commands.Interfaces;
using Flunt.Notifications;
using Flunt.Validations;

namespace Aphrodite.Domain.CoreContext.Commands.FileCommands.Inputs;

public class CreateFileCommand : Notifiable<Notification>, ICommand
{
    public Byte[] File { get; set; }
    public Guid CreativeId { get; set; }
    
    public bool Valid()
    {
        AddNotifications(new Contract<CreateFileCommand>()
            .Requires()
        );

        return IsValid;
    }
}