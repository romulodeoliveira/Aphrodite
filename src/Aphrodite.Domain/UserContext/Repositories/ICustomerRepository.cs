using Aphrodite.Domain.UserContext.Entities;

namespace Aphrodite.Domain.UserContext.Repositories;

public interface ICustomerRepository
{
    public Customer GetById(Guid id);
}