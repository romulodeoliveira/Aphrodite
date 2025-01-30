using Aphrodite.Domain.Shared.Entities;
using Aphrodite.Domain.UserContext.Entities;
using Flunt.Validations;

namespace Aphrodite.Domain.CoreContext.Entities;

public class Comment : BaseEntity
{
    public Comment(
        string content, 
        BaseUser author)
    {
        Content = content;
        Author = author;
        CreatedAt = DateTime.Now;
        
        AddNotifications(
            new Contract<Comment>()
                .Requires()
                .IsTrue(content.Length < 200, "Content", "O conteúdo não pode ser maior que 200 caracteres.")
                .IsNotNullOrEmpty(content, "Content", "A conteúdo não pode estar vazio.")
                .IsNotNull(author, "Author", "O campo 'autor' não pode estar vazio.")
        );
    }
    
    public string Content { get; private set; }
    public BaseUser Author { get; private set; }
    public DateTime CreatedAt { get; private set; }
}