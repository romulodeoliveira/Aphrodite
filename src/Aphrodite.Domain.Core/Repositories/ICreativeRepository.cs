using Aphrodite.Domain.Core.Entities;

namespace Aphrodite.Domain.Core.Repositories;

public interface ICreativeRepository
{
    public void Save(Creative creative);
}