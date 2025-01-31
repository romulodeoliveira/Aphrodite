using File = Aphrodite.Domain.CoreContext.Entities.File;

namespace Aphrodite.Domain.CoreContext.Repositories;

public interface IFileRepository
{
    public void Save(File file);
    public bool Exists(Guid fileId);
    public File GetById(Guid fileId);
    public void Update(File file);
}