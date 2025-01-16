using Aphrodite.Domain.Shared.Entities;

namespace Aphrodite.Domain.Core.Entities;

public class Creative : BaseEntity
{
    private readonly IList<Comment> _comments;
    
    public Creative(
        string title, 
        string description, 
        DateTime postingDate,
        Admin creator, 
        Customer customer, 
        Byte[] imageOrVideo)
    {
        Title = title;
        Description = description;
        IsApproved = false;
        IsScheduled = false;
        PostingDate = postingDate;
        CreatedAt = DateTime.Now;
        Creator = creator;
        Customer = customer;
        ImageOrVideo = imageOrVideo;
        _comments = new List<Comment>();
    }

    public string Title { get; private set; }
    public string Description { get; private set; }
    public bool IsApproved { get; private set; }
    public bool IsScheduled { get; private set; }
    public DateTime PostingDate { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? ModifiedAt { get; private set; }
    public Admin Creator { get; private set; }
    public Customer Customer { get; private set; }
    public Byte[] ImageOrVideo { get; private set; }
    public IReadOnlyCollection<Comment> Comments => _comments.ToArray();

    public void MarkAsApproved(Comment comment)
    {
        IsApproved = true;
        AddComment(comment);
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

    public void UpdatePostingDate(DateTime newPostingDate)
    {
        PostingDate = newPostingDate;
        ModifiedAt = DateTime.Now;
    }

    public void MarkAsScheduled()
    {
        IsScheduled = true;
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public void UpdateImageOrVideo(byte[] newImageOrVideo, Comment comment)
    {
        ImageOrVideo = newImageOrVideo;
        AddComment(comment);
    }
}