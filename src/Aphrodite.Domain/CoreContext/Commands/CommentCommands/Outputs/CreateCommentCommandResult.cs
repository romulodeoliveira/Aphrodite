using Aphrodite.Domain.Shared.Commands.Interfaces;

namespace Aphrodite.Domain.CoreContext.Commands.CommentCommands.Outputs;

public class CreateCommentCommandResult : ICommandResult
{
    public CreateCommentCommandResult(
        Guid id, 
        string content, 
        Guid authorId)
    {
        Id = id;
        Content = content;
        AuthorId = authorId;
    }

    public Guid Id { get; set; }
    public string Content { get; set; }
    public Guid AuthorId { get; set; }
}