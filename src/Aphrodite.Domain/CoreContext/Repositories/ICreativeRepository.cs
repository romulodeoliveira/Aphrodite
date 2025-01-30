using Aphrodite.Domain.CoreContext.Entities;

namespace Aphrodite.Domain.CoreContext.Repositories;

public interface ICreativeRepository
{
    public void Save(Creative creative);
}