using Aphrodite.Domain.Shared.Commands.Interfaces;

namespace Aphrodite.Domain.CoreContext.Commands.FileCommands.Outputs;

public class UpdateFileCommandResult : ICommandResult
{
    public UpdateFileCommandResult(Guid fileId, byte[] archive, Guid creativeId)
    {
        FileId = fileId;
        Archive = archive;
        CreativeId = creativeId;
    }

    public Guid FileId { get; set; }
    public Byte[] Archive { get; set; }
    public Guid CreativeId { get; private set; }
}