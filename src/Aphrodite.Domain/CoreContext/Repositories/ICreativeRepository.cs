using Aphrodite.Domain.CoreContext.Entities;

namespace Aphrodite.Domain.CoreContext.Repositories;

public interface ICreativeRepository
{
    public Creative GetById(Guid creativeId);
    public bool CreativeExists(Guid creativeId);
    public void Save(Creative creative);
}