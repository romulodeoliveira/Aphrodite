using Aphrodite.Domain.Shared.Commands.Interfaces;

namespace Aphrodite.Domain.CoreContext.Commands.FileCommands.Outputs;

public class CreateFileCommandResult : ICommandResult
{
    public CreateFileCommandResult(
        byte[] file, 
        Guid creativeId)
    {
        File = file;
        CreativeId = creativeId;
    }

    public Byte[] File { get; set; }
    public Guid CreativeId { get; set; }
}