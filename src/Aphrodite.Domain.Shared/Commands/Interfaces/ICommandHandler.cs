namespace Aphrodite.Domain.Shared.Commands.Interfaces;

public interface ICommandHandler<T> where T : ICommand
{
    ICommandResult Handle(T command);
}