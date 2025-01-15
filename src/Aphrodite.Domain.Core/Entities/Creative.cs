using Aphrodite.Domain.Shared.Entities;

namespace Aphrodite.Domain.Core.Entities;

public class Creative : BaseEntity
{
    public Creative(
        string title, 
        string description, 
        Admin creator, 
        Customer customer, 
        Byte[] imageOrVideo)
    {
        Title = title;
        Description = description;
        IsApproved = false;
        CreatedAt = DateTime.Now;
        Creator = creator;
        Customer = customer;
        ImageOrVideo = imageOrVideo;
    }

    public string Title { get; private set; }
    public string Description { get; private set; }
    public bool IsApproved { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? ModifiedAt { get; private set; }
    public Admin Creator { get; private set; }
    public Customer Customer { get; private set; }
    public Byte[] ImageOrVideo { get; private set; }

    public void MarkAsApproved()
    {
        IsApproved = true;
    }
    
    public void UpdateTitle(string newTitle)
    {
        Title = newTitle;
        ModifiedAt = DateTime.Now;
    }
    
    public void UpdateDescription(string newDescription)
    {
        Description = newDescription;
        ModifiedAt = DateTime.Now;
    }
}