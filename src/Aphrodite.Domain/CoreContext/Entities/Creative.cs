using Aphrodite.Domain.CoreContext.Enums;
using Aphrodite.Domain.CoreContext.Utils;
using Aphrodite.Domain.Shared.Entities;
using Aphrodite.Domain.UserContext.Entities;
using Flunt.Validations;

namespace Aphrodite.Domain.CoreContext.Entities;

public class Creative : BaseEntity
{
    private readonly IList<Comment> _comments;
    private readonly IList<File> _files;
    
    public Creative(
        string title, 
        string description, 
        DateTime postingDate,
        Admin creator, 
        Customer customer,
        ETypeOfPost typeOfPost)
    {
        Title = title;
        Description = description;
        IsApproved = false;
        IsScheduled = false;
        PostingDate = postingDate;
        CreatedAt = DateTime.Now;
        Creator = creator;
        Customer = customer;
        TypeOfPost = typeOfPost;
        _files = new List<File>();
        _comments = new List<Comment>();
        
        AddNotifications(
            new Contract<Creative>()
                .Requires()
                .IsTrue(title.Length < 30, "Title", "O título não pode ser maior que 30 caracteres.")
                .IsNotNullOrEmpty(title, "Title", "O título não pode ser vazio.")
                .IsTrue(description.Length < 100, "Description", "A descrição não pode ser maior que 100 caracteres.")
                .IsNotNullOrEmpty(description, "Description", "A descrição não pode ser vazia.")
                .IsNotNull(postingDate, "PostingDate", "A data de postagem não pode estar vazia.")
                .IsGreaterOrEqualsThan(postingDate, DateTime.Now, "PostingDate", "A data de postagem não pode ser no passado.")
                .IsNotNull(creator, "Admin", "O campo 'criador' não pode estar vazio.")
                .IsNotNull(customer, "Customer", "O campo 'cliente' não pode estar vazio.")
                .IsTrue(Enum.IsDefined(typeof(ETypeOfPost), typeOfPost), "TypeOfPost", "O tipo de post fornecido é inválido")
            );
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
    public ETypeOfPost TypeOfPost { get; private set; }
    public IReadOnlyCollection<File> File { get; private set; }
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
        
        AddNotifications(
            new Contract<Creative>()
                .Requires()
                .IsTrue(newTitle.Length < 30, "Title", "O título não pode ser maior que 30 caracteres.")
                .IsNotNullOrEmpty(newTitle, "Title", "O título não pode ser vazio.")
        );
    }
    
    public void UpdateDescription(string newDescription)
    {
        Description = newDescription;
        ModifiedAt = DateTime.Now;
        
        AddNotifications(
            new Contract<Creative>()
                .Requires()
                .IsTrue(newDescription.Length < 100, "Description", "A descrição não pode ser maior que 100 caracteres.")
                .IsNotNullOrEmpty(newDescription, "Description", "A descrição não pode ser vazia.")
        );
    }

    public void UpdatePostingDate(DateTime newPostingDate)
    {
        PostingDate = newPostingDate;
        ModifiedAt = DateTime.Now;
        
        AddNotifications(
            new Contract<Creative>()
                .Requires()
                .IsNotNull(newPostingDate, "PostingDate", "A data de postagem não pode estar vazia.")
                .IsGreaterOrEqualsThan(newPostingDate, DateTime.Now, "PostingDate", "A data de postagem não pode ser no passado.")
        );
    }

    public void MarkAsScheduled()
    {
        IsScheduled = true;
    }

    public void AddComment(Comment comment)
    {
        if (comment.IsValid)
        {
            _comments.Add(comment);
        }
        else
        {
            AddNotifications(comment.Notifications);
        }
    }

    public void UpdateTypeOfPost(ETypeOfPost newTypeOfPost)
    {
        TypeOfPost = newTypeOfPost;
        
        AddNotifications(
            new Contract<Creative>()
                .Requires()
                .IsTrue(Enum.IsDefined(typeof(ETypeOfPost), newTypeOfPost), "TypeOfPost", "O tipo de post fornecido é inválido")
        );
    }
}