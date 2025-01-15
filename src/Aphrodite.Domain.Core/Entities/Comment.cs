using Aphrodite.Domain.Shared.Entities;

namespace Aphrodite.Domain.Core.Entities;

public class Comment : BaseEntity
{
    public Comment(
        string content, 
        BaseUser author)
    {
        Content = content;
        Author = author;
        CreatedAt = DateTime.Now;
    }
    
    public string Content { get; private set; }
    public BaseUser Author { get; private set; }
    public DateTime CreatedAt { get; private set; }
}