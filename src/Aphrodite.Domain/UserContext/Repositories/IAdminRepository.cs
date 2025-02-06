using Aphrodite.Domain.UserContext.Entities;

namespace Aphrodite.Domain.UserContext.Repositories;

public interface IAdminRepository
{
    public Admin GetById(Guid id);
}