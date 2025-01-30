using Aphrodite.Domain.CoreContext.Commands.CommentCommands.Inputs;
using Aphrodite.Domain.CoreContext.Commands.CommentCommands.Outputs;
using Aphrodite.Domain.CoreContext.Commands.CreativeCommands.Outputs;
using Aphrodite.Domain.CoreContext.Entities;
using Aphrodite.Domain.CoreContext.Repositories;
using Aphrodite.Domain.Shared.Commands.Interfaces;
using Flunt.Notifications;

namespace Aphrodite.Domain.CoreContext.Handlers;

public class CommentHandler :
    Notifiable<Notification>, 
    ICommandHandler<CreateCommentCommand>
{
    private readonly ICommentRepository _commentRepository;

    public CommentHandler(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }
    
    public ICommandResult Handle(CreateCommentCommand command)
    {
        // verificar se o ID pertence a um User
        if (_commentRepository.UserExists(command.AuthorId) == false)
        {
            AddNotification("AuthorId", "Usuário não registrado");
        }
        
        // criar as entidades
        var user = _commentRepository.GetUserById(command.AuthorId);
        var comment = new Comment(command.Content, user);

        // aplicar as validações
        AddNotifications(comment.Notifications);

        if (IsValid == false)
        {
            return null;
        }
        
        // persistir o comentário
        _commentRepository.Save(comment);
        
        // retornar o resultado para a tela
        return new CreateCommentCommandResult(
            comment.Id,
            comment.Content,
            comment.Author.Id);
    }
}