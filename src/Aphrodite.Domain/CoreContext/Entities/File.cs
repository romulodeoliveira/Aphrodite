using Aphrodite.Domain.CoreContext.Utils;
using Aphrodite.Domain.Shared.Entities;
using Flunt.Validations;

namespace Aphrodite.Domain.CoreContext.Entities;

public class File : BaseEntity
{
    public File(
        byte[] archive, 
        Creative creative)
    {
        Archive = archive;
        Creative = creative;

        AddNotifications(
            new Contract<File>()
                .Requires()
                .IsTrue(FileValidator.IsSupportedImageOrVideo(archive), "Archive", "São aceitos apenas arquivos do tipo '.mp4', '.mov', '.jpg', 'jpeg' e '.png'.")
                .IsNotNull(archive, "Archive", "O arquivo de imagem ou vídeo não pode estar vazio.")
            );
    }

    public Byte[] Archive { get; private set; }
    public Creative Creative { get; private set; }
    
    public void UpdateArchive(byte[] newArchive)
    {
        Archive = newArchive;
        
        AddNotifications(
            new Contract<Creative>()
                .Requires()
                .IsTrue(FileValidator.IsSupportedImageOrVideo(newArchive), "Archive", "São aceitos apenas arquivos do tipo '.mp4', '.mov', '.jpg', 'jpeg' e '.png'.")
                .IsNotNull(newArchive, "Archive", "O arquivo de imagem ou vídeo não pode estar vazio.")
        );
    }
}