using Aphrodite.Domain.UserContext.Entities;

namespace Aphrodite.Domain.UserContext.Repositories;

public interface ICustomerRepository
{
    bool Exists(Guid id);
    public Customer GetById(Guid id);
}