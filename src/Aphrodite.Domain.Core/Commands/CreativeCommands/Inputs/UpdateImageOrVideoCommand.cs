using Aphrodite.Domain.Core.Commands.CommentCommands.Inputs;

namespace Aphrodite.Domain.Core.Commands.CreativeCommands.Inputs;

public class UpdateImageOrVideoCommand
{
    public Byte[] File { get; set; }
    public CreateCommentCommand Comment { get; set; }
}