using Aphrodite.Domain.CoreContext.Entities;
using Aphrodite.Domain.Shared.Commands.Interfaces;
using Flunt.Notifications;
using Flunt.Validations;

namespace Aphrodite.Domain.CoreContext.Commands.FileCommands.Inputs;

public class UpdateFileCommand : Notifiable<Notification>, ICommand
{
    public Guid FileId { get; set; }
    public Byte[] Archive { get; set; }
    
    public bool Valid()
    {
        AddNotifications(new Contract<UpdateFileCommand>()
            .Requires()
            .IsNotNullOrEmpty(FileId.ToString(), "AuthorId", "É necessário inserir o ID do arquivo.")
            .IsFalse(FileId == Guid.Empty, "FileId", "O ID do arquivo é inválido.")
        );

        return IsValid;
    }
}