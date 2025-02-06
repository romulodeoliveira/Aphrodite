using Aphrodite.Domain.CoreContext.Commands.CommentCommands.Inputs;
using Aphrodite.Domain.CoreContext.Commands.CreativeCommands.Inputs;
using Aphrodite.Domain.CoreContext.Commands.CreativeCommands.Outputs;
using Aphrodite.Domain.CoreContext.Entities;
using Aphrodite.Domain.CoreContext.Repositories;
using Aphrodite.Domain.CoreContext.Services;
using Aphrodite.Domain.Shared.Commands.Interfaces;
using Aphrodite.Domain.UserContext.Entities;
using Aphrodite.Domain.UserContext.Repositories;
using Aphrodite.Domain.UserContext.ValueObjects;
using Flunt.Notifications;

namespace Aphrodite.Domain.CoreContext.Handlers;

public class CreativeHandler : 
    Notifiable<Notification>, 
    ICommandHandler<CreateCreativeCommand>,
    ICommandHandler<UpdateDescriptionCommand>,
    ICommandHandler<UpdatePostingDateCommand>,
    ICommandHandler<UpdateTitleCommand>,
    ICommandHandler<UpdateTypeOfPostCommand>
{
    private readonly ICreativeRepository _creativeRepository;
    private readonly IAdminRepository _adminRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly IEmailService _emailService;
    
    public CreativeHandler(
        ICreativeRepository creativeRepository,
        IAdminRepository adminRepository,
        ICustomerRepository customerRepository,
        IEmailService emailService)
    {
        _creativeRepository = creativeRepository;
        _adminRepository = adminRepository;
        _customerRepository = customerRepository;
        _emailService = emailService;
    }
    
    public ICommandResult Handle(CreateCreativeCommand command)
    {
        // puxar os usuários relacionados
        if (
            _adminRepository.Exists(command.AdminId) && 
            _customerRepository.Exists(command.CustomerId))
        {
            var admin = _adminRepository.GetById(command.AdminId);
            var customer = _customerRepository.GetById(command.CustomerId);
            
            // Criar a Entidade
            var creative = new Creative(
                command.Title, 
                command.Description, 
                command.PostingDate, 
                admin, 
                customer, 
                command.TypeOfPost);
            
            // Validar entidade
            AddNotifications(creative.Notifications);

            if (IsValid == false)
            {
                return null;
            }
        
            // Persistir o Criativo
            _creativeRepository.Save(creative);
        
            // Enviar notificação via e-mail para o cliente
            _emailService.Send(
                customer.Email.Address, 
                admin.Email.Address, 
                "Nova Notificação", 
                "Você possui um novo criativo pendente de aprovação.");
        
            // TODO
            // Enviar notificação via Whatsapp para o cliente
        
            // Retornar o resultado para a tela
            return new CreateCreativeCommandResult(
                creative.Id, 
                creative.Title, 
                creative.Description, 
                creative.PostingDate, 
                admin.Name.FirstName, 
                admin.Name.LastName, 
                admin.Email.Address, 
                customer.Name.FirstName, 
                customer.Name.LastName, 
                customer.Email.Address, 
                customer.Document.Number, 
                customer.Document.Type, 
                creative.TypeOfPost);
        }
        else
        {
            return null;
        }
    }

    public ICommandResult Handle(UpdateDescriptionCommand command)
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