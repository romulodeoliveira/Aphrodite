using Aphrodite.Domain.Core.Enums;
using Aphrodite.Domain.Shared.Commands.Interfaces;
using Aphrodite.Domain.Shared.Enums;

namespace Aphrodite.Domain.Core.Commands.CreativeCommands.Outputs;

public class CreateCreativeCommandResult : ICommandResult
{
    public CreateCreativeCommandResult() {}
    
    public CreateCreativeCommandResult(
        Guid id, 
        string title, 
        string description, 
        DateTime postingDate, 
        string adminFirstName, 
        string adminLastName, 
        string adminEmailAddress, 
        string customerFirstName, 
        string customerLastName, 
        string customerEmailAddress, 
        string customerDocumentNumber, 
        EDocumentType type, 
        ETypeOfPost typeOfPost, 
        byte[] file)
    {
        Id = id;
        Title = title;
        Description = description;
        PostingDate = postingDate;
        AdminFirstName = adminFirstName;
        AdminLastName = adminLastName;
        AdminEmailAddress = adminEmailAddress;
        CustomerFirstName = customerFirstName;
        CustomerLastName = customerLastName;
        CustomerEmailAddress = customerEmailAddress;
        CustomerDocumentNumber = customerDocumentNumber;
        Type = type;
        TypeOfPost = typeOfPost;
        File = file;
    }

    public Guid Id { get; set; }
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
}