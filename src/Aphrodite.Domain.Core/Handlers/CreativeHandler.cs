using Aphrodite.Domain.Core.Commands.CreativeCommands.Inputs;
using Aphrodite.Domain.Core.Commands.CreativeCommands.Outputs;
using Aphrodite.Domain.Core.Entities;
using Aphrodite.Domain.Shared.Commands.Interfaces;
using Aphrodite.Domain.Shared.Entities;
using Aphrodite.Domain.Shared.ValueObjects;
using Flunt.Notifications;

namespace Aphrodite.Domain.Core.Handlers;

public class CreativeHandler : 
    Notifiable<Notification>, 
    ICommandHandler<CreateCreativeCommand>,
    ICommandHandler<AddCommentCommand>,
    ICommandHandler<UpdateDescriptionCommand>,
    ICommandHandler<UpdateImageOrVideoCommand>,
    ICommandHandler<UpdatePostingDateCommand>,
    ICommandHandler<UpdateTitleCommand>,
    ICommandHandler<UpdateTypeOfPostCommand>
{
    public ICommandResult Handle(CreateCreativeCommand command)
    {
        // verificar se o e-mail já existe na base
        
        // Criar VOs
        var adminName = new Name(
            command.AdminFirstName, 
            command.AdminLastName);
        var adminEmail = new Email(
            command.AdminEmailAddress);
        var admin = new Admin(
            adminName, 
            adminEmail);

        var customerName = new Name(
            command.CustomerFirstName, 
            command.CustomerLastName);
        var customerEmail = new Email(
            command.CustomerEmailAddress);
        var customerDocument = new Document(
            command.CustomerDocumentNumber, 
            command.Type);
        var customer = new Customer(
            customerName, 
            customerEmail, 
            customerDocument);
        
        // Criar a Entidade 
        var creative = new Creative(
            command.Title, 
            command.Description, 
            command.PostingDate, 
            admin, 
            customer, 
            command.TypeOfPost, 
            command.File);
        
        // Validar entidades e VOs
        AddNotifications(adminName.Notifications);
        AddNotifications(adminEmail.Notifications);
        
        // Persistir o Criativo
        
        // Enviar notificação via e-mail para o cliente
        
        // Enviar notificação via Whatsapp para o cliente
        
        // Retornar o resultado para a tela
        return new CreateCreativeCommandResult(
            creative.Id, 
            creative.Title, 
            creative.Description, 
            creative.PostingDate, 
            adminName.FirstName, 
            adminName.LastName, 
            adminEmail.Address, 
            customerName.FirstName, 
            customerName.LastName, 
            customerEmail.Address, 
            customerDocument.Number, 
            customerDocument.Type, 
            creative.TypeOfPost, 
            creative.File);
    }

    public ICommandResult Handle(AddCommentCommand command)
    {
        throw new NotImplementedException();
    }

    public ICommandResult Handle(UpdateDescriptionCommand command)
    {
        throw new NotImplementedException();
    }

    public ICommandResult Handle(UpdateImageOrVideoCommand command)
    {
        throw new NotImplementedException();
    }

    public ICommandResult Handle(UpdatePostingDateCommand command)
    {
        throw new NotImplementedException();
    }

    public ICommandResult Handle(UpdateTitleCommand command)
    {
        throw new NotImplementedException();
    }

    public ICommandResult Handle(UpdateTypeOfPostCommand command)
    {
        throw new NotImplementedException();
    }
}