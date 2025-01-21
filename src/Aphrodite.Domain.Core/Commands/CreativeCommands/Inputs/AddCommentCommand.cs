using Aphrodite.Domain.Core.Commands.CommentCommands.Inputs;

namespace Aphrodite.Domain.Core.Commands.CreativeCommands.Inputs;

public class AddCommentCommand
{
    public CreateCommentCommand Comment { get; set; }
}