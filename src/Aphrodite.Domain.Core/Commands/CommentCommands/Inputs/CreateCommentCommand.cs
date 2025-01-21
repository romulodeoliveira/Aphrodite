namespace Aphrodite.Domain.Core.Commands.CommentCommands.Inputs;

public class CreateCommentCommand
{
    public string Content { get; private set; }
    public Guid AuthorId { get; private set; }
}