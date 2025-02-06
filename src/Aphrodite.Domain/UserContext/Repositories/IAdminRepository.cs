using Aphrodite.Domain.UserContext.Entities;

namespace Aphrodite.Domain.UserContext.Repositories;

public interface IAdminRepository
{
    bool Exists(Guid id);
    public Admin GetById(Guid id);
}