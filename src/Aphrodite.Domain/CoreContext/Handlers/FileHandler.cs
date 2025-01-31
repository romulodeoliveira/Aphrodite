using Aphrodite.Domain.CoreContext.Commands.FileCommands.Inputs;
using Aphrodite.Domain.CoreContext.Commands.FileCommands.Outputs;
using Aphrodite.Domain.CoreContext.Repositories;
using Aphrodite.Domain.Shared.Commands.Interfaces;
using Flunt.Notifications;
using File = Aphrodite.Domain.CoreContext.Entities.File;

namespace Aphrodite.Domain.CoreContext.Handlers;

public class FileHandler :
    Notifiable<Notification>, 
    ICommandHandler<CreateFileCommand>,
    ICommandHandler<UpdateFileCommand>
{
    private readonly ICreativeRepository _creativeRepository;
    private readonly IFileRepository _fileRepository;

    public FileHandler(
        ICreativeRepository creativeRepository,
        IFileRepository fileRepository)
    {
        _creativeRepository = creativeRepository;
        _fileRepository = fileRepository;
    }
    
    public ICommandResult Handle(CreateFileCommand command)
    {
        // verificar se o ID pertence a algum Criativo
        if (_creativeRepository.CreativeExists(command.CreativeId) == false)
        {
            AddNotification("CreativeId", "Criativo não existe");
        }
        
        // criar as entidades
        var creative = _creativeRepository.GetById(command.CreativeId);
        var file = new File(command.File, creative);
        
        // aplicar as validações
        AddNotifications(file.Notifications);

        if (IsValid == false)
        {
            return null;
        }
        
        // persistir o arquivo
        _fileRepository.Save(file);
        
        // retornar o resultado para a tela
        return new CreateFileCommandResult(
            file.Archive, 
            file.Creative.Id);
    }

    public ICommandResult Handle(UpdateFileCommand command)
    {
        // verificar se o arquivo existe
        if (_fileRepository.Exists(command.FileId) == false)
        {
            AddNotification("FileId", "Arquivo não existe");
        }
        
        // puxar o arquivo salvo no banco
        var file = _fileRepository.GetById(command.FileId);
        
        // setar o novo arquivo
        file.UpdateArchive(command.Archive);
        
        // aplicar as validações
        AddNotifications(file.Notifications);

        if (IsValid == false)
        {
            return null;
        }
        
        // persistir o arquivo
        _fileRepository.Update(file);
        
        // retornar o resultado para a tela
        return new UpdateFileCommandResult(
            file.Id,
            file.Archive, 
            file.Creative.Id);
    }
}