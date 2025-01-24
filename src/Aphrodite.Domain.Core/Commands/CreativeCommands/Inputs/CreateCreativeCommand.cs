using Aphrodite.Domain.Core.Entities;
using Aphrodite.Domain.Core.Enums;
using Aphrodite.Domain.Shared.Commands.Interfaces;
using Aphrodite.Domain.Shared.Enums;
using Flunt.Notifications;

namespace Aphrodite.Domain.Core.Commands.CreativeCommands.Inputs;

public class CreateCreativeCommand : Notifiable<Notification>, ICommand
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime PostingDate { get; set; }
    public string AdminFirstName { get; set; }
    public string AdminLastName { get; set; }
    public string AdminEmailAddress { get; set; }
    public string CustomerFirstName { get; set; }
    public string CustomerLastName { get; set; }
    public string CustomerEmailAddress { get; set; }
    public string CustomerDocumentNumber { get; set; }
    public EDocumentType Type { get; set; }
    public ETypeOfPost TypeOfPost { get; set; }
    public Byte[] File { get; set; }
    
    public bool Valid()
    {
        throw new NotImplementedException();
    }
}