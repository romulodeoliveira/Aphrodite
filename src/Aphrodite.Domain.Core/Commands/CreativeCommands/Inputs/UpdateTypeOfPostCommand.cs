using Aphrodite.Domain.Core.Enums;

namespace Aphrodite.Domain.Core.Commands.CreativeCommands.Inputs;

public class UpdateTypeOfPostCommand
{
    public ETypeOfPost TypeOfPost { get; set; }
}